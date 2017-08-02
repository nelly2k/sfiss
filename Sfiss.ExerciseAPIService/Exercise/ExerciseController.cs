using System.Web.Http;
using System.Web.Http.Cors;
using Sfiss.Common.Model;

namespace Sfiss.ExerciseAPIService.Exercise
{
    [ServiceRequestActionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExerciseController : ApiController
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