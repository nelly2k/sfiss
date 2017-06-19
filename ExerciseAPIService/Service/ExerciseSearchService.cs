using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ExerciseAPIService.Model;
using Dapper;
using ExerciseAPIService.App;

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
            var sb = new StringBuilder("SELECT Id, Title FROM [Exercise] WHERE")

                .AppendNotNull(request.Title, "Title like ");



            if (!string.IsNullOrEmpty(request.Title))
            {
                sb.Append(" EXISTS(SELECT * FROM [ExerciseMuscle] em WHERE em.ExerciseId = e.Id and em.MuscleId = 1)");
            }
            

            IEnumerable<Entity> result = null;
            _dbService.Run(cn => result = cn.Query<Entity>("SELECT Id, Title FROM Exercise"));
            return new SearchResponse
            {
                Data = result
            };

        }
    }
}