using Dapper;
using ExerciseAPIService.Model;

namespace ExerciseAPIService.Service
{
    public interface IRequestService
    {
        void Create(AddRequest request);
    }

    public class RequestService : IRequestService
    {
        private readonly IDbService _dbService;

        public RequestService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public void Create(AddRequest request)
        {
            _dbService.Run(cn=>cn.Execute("INSERT INTO Request VALUES (@Title, @OtherTitles, @Complexity, @Notes, @CreatedBy, @ExerciseId, 0)",
                new {request.Title, request.OtherTitles, request.Complexity, request.Notes, request.CreatedBy, ExerciseId = request.Id}));
        }
    }
}