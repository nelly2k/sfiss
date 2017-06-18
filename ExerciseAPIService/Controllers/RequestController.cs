using System.Web.Http;
using ExerciseAPIService.Model;

namespace ExerciseAPIService.Controllers
{
    [ServiceRequestActionFilter]
    public class RequestController:ApiController
    {

        // POST api/request 
        public void Post([FromBody]AddRequest value)
        {
        }

        // PUT api/request/5 
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
