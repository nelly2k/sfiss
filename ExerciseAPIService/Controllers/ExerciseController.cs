using System;
using System.Web.Http;
using ExerciseAPIService.Model;
using ExerciseAPIService.Service;

namespace ExerciseAPIService.Controllers
{
    [ServiceRequestActionFilter]
    public class ExerciseController:ApiController
    {
        private readonly IExerciseSearchService _exerciseSearchService;

        public ExerciseController(IExerciseSearchService exerciseSearchService)
        {
            _exerciseSearchService = exerciseSearchService;
        }

        public Exercise Get(int id)
        {
            throw new NotImplementedException();
        }

        public SearchResponse Post([FromBody] SearchExerciseRequest request)
        {
            return _exerciseSearchService.Search(request);
        }
    }
}
