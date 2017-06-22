using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using Sfiss.Common.Database;
using Sfiss.Common.Model;
using Dapper;

namespace ExerciseAPIService.Service
{
    public interface IRepositoryService
    {
        PaginationResult<T> Search<T>(SearchRequest request, string tableName, string orderByDefault,
            Action<StringBuilder, ExpandoObject> buildSearchParams);

        T Get<T>(int id);
    }

    public class RepositoryService : IRepositoryService
    {
        private readonly IDbService _dbService;

        public RepositoryService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public PaginationResult<T> Search<T>(SearchRequest request, string tableName, string orderByDefault,
            Action<StringBuilder, ExpandoObject> buildSearchParams)
        {
            request.OrderBy = request.OrderBy ?? "Title";

            dynamic parameters = new ExpandoObject();
            var sb = new StringBuilder();
            buildSearchParams.Invoke(sb, parameters);
            sb.Where();
            sb.Insert(0, $"select * from [{tableName}]");
            var result = new PaginationResult<T>();
            _dbService.Run(cn => result.Data = cn.Query<T>(sb.ToString(), (object)parameters));
            sb.Remove(0, 1);
            sb.Pagination(request);
            sb.Insert(0, $"select count(*) from [{tableName}]");
            _dbService.Run(cn => result.Total = cn.Query<int>(sb.ToString(), (object)parameters).SingleOrDefault());
            return result;
        }

        public T Get<T>(int id)
        {
            var tableName = typeof(T).Name;
            var result = default(T);
            _dbService.Run(cn => result = cn.Query<T>($"SELECT * FROM {tableName} WHERE Id = @id", new { Id = id }).SingleOrDefault());
            return result;
        }
    }
}