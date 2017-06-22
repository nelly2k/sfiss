using System;
using System.Web.Http;
using ExerciseAPIService.Model;
using ExerciseAPIService.Service;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Controllers
{
    public class MuscleController:ApiController
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
