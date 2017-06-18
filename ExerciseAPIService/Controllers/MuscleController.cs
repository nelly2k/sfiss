using System;
using System.Web.Http;
using ExerciseAPIService.Model;

namespace ExerciseAPIService.Controllers
{
    public class MuscleController:ApiController
    {
        public SearchResponse Post([FromBody] SearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
