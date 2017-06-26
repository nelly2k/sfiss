using System.Web.Http;
using Sfiss.Common.Model;

namespace Sfiss.ExerciseAPIService.Muscle
{
    public class MuscleController : ApiController
    {
        private readonly IMuscleServise _muscleServise;

        public MuscleController(IMuscleServise muscleServise)
        {
            _muscleServise = muscleServise;
        }
        public PaginationResult<Muscle> Post([FromBody] SearchMuscleRequest request)
        {
            return _muscleServise.Search(request);
        }
    }
}
