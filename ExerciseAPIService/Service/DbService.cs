using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExerciseAPIService.App;

namespace ExerciseAPIService.Service
{
    public interface IDbService
    {
        void Run(Action<IDbConnection> dbAction);
    }

    public class DbService : IDbService
    {
        private readonly IExerciseConfiguration _exerciseConfiguration;

        public DbService(IExerciseConfiguration exerciseConfiguration)
        {
            _exerciseConfiguration = exerciseConfiguration;
        }

        internal IDbConnection Connection => new SqlConnection(_exerciseConfiguration.ConnectionString);


        public void Run(Action<IDbConnection> dbAction)
        {
            using (var cn = Connection)
            {
                cn.Open();
                dbAction(cn);
                cn.Close();
            }
        }

      //  public IEnumerable<T> Query<T> ()
       
    }
}