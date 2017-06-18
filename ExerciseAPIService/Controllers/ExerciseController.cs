using System;
using System.Web.Http;
using ExerciseAPIService.App;
using ExerciseAPIService.Model;
using ExerciseAPIService.Service;

namespace ExerciseAPIService.Controllers
{
    [ServiceRequestActionFilter]
    public class ExerciseController:ApiController
    {
        private readonly IExerciseSearchService _exerciseSearchService;
        private readonly IExerciseConfiguration _configuration;

        public ExerciseController(IExerciseSearchService exerciseSearchService, IExerciseConfiguration configuration)
        {
            _exerciseSearchService = exerciseSearchService;
            _configuration = configuration;
        }

        public Exercise Get(int id)
        {
            throw new NotImplementedException();
        }

        public SearchResponse Post([FromBody] SearchExerciseRequest request)
        {
            var cs = _configuration.ConnectionString;
            return _exerciseSearchService.Search(request);
        }
    }
}
