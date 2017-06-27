using System;
using System.Dynamic;
using System.Linq;
using System.Text;
using Dapper;
using Sfiss.Common.Contract;
using Sfiss.Common.Model;

namespace Sfiss.Common.Database
{
    public interface IRepositoryService:IService
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
            buildSearchParams(sb, parameters);
            sb.Pagination(request);
            sb.Where();
            var newSb = new StringBuilder(sb.ToString());
            sb.Insert(0, $"select * from [{tableName}] e");

            var result = new PaginationResult<T>();
            _dbService.Run(cn => result.Data = cn.Query<T>(sb.ToString(), (object)parameters));

            newSb.Insert(0, $"select count(*) from [{tableName}] e");
            _dbService.Run(cn => result.Total = cn.Query<int>(newSb.ToString(), (object)parameters).SingleOrDefault());
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
