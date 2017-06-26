using System;
using System.Data;
using System.Data.SqlClient;
using Sfiss.Common.Contract;

namespace Sfiss.Common.Database
{
    public interface IDbService: IService
    {
        void Run(Action<IDbConnection> dbAction);
    }

    public class DbService : IDbService
    {
        private readonly IConnectionStringConfiguration _exerciseConfiguration;

        public DbService(IConnectionStringConfiguration exerciseConfiguration)
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
    }
}
