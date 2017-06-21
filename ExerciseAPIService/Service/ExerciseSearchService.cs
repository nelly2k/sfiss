using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ExerciseAPIService.Model;
using Dapper;
using ExerciseAPIService.App;
using System;
using System.Dynamic;

namespace ExerciseAPIService.Service
{
    public interface IExerciseSearchService
    {
        SearchResponse Search(SearchExerciseRequest request);
    }

    public class ExerciseSearchService : IExerciseSearchService
    {
        private readonly IExerciseConfiguration _exerciseConfiguration;
        private readonly IDbService _dbService;

        public ExerciseSearchService(IExerciseConfiguration exerciseConfiguration, IDbService dbService)
        {
            _exerciseConfiguration = exerciseConfiguration;
            _dbService = dbService;
        }
        internal IDbConnection Connection => new SqlConnection(_exerciseConfiguration.ConnectionString);


        public SearchResponse Search(SearchExerciseRequest request)
        {
            dynamic parameters = new ExpandoObject();
            var sb = new StringBuilder("SELECT Id, Title FROM [Exercise] WHERE")
                .AppendNotNull(request.Title, " Title LIKE CONCAT('%',@Title,'%') ",()=>parameters.Title = request.Title);

            IEnumerable<Entity> result = null;
            _dbService.Run(cn => result = cn.Query<Entity>(sb.ToString(), (object)parameters));
            return new SearchResponse
            {
                Data = result
            };

        }
    }
}