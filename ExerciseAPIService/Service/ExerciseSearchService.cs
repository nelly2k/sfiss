using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using ExerciseAPIService.Model;
using System.Fabric;
using Dapper;
using ExerciseAPIService.App;

namespace ExerciseAPIService.Service
{
    public interface IExerciseSearchService
    {
        SearchResponse Search(SearchRequest request);
    }

    public class ExerciseSearchService : IExerciseSearchService
    {
        private readonly IExerciseConfiguration _exerciseConfiguration;

        public ExerciseSearchService(IExerciseConfiguration exerciseConfiguration)
        {
            _exerciseConfiguration = exerciseConfiguration;
        }
        internal IDbConnection Connection => new SqlConnection(_exerciseConfiguration.ConnectionString);


        public SearchResponse Search(SearchRequest request)
        {
            IEnumerable<Entity> result;
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                result = cn.Query<Entity>("SELECT * FROM Exercise");
            }


            return new SearchResponse()
            {
                Data = result
            };
        }
    }
}