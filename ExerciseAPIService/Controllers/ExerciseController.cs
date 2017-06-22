using System;
using System.Web.Http;
using ExerciseAPIService.Model;
using ExerciseAPIService.Service;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Controllers
{
    [ServiceRequestActionFilter]
    public class ExerciseController:ApiController
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public Exercise Get(int id)
        {
            return _exerciseService.Get(id);
        }

        public PaginationResult<ExerciseBrief> Post([FromBody] SearchExerciseRequest request)
        {
            return _exerciseService.Search(request);
        }
    }
}
