using System.Web.Http;
using ExerciseAPIService.Model;
using ExerciseAPIService.Service;

namespace ExerciseAPIService.Controllers
{
    [ServiceRequestActionFilter]
    public class RequestController:ApiController
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public void Post([FromBody]AddRequest request)
        {
            _requestService.Create(request);
        }
    }
}
