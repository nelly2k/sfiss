using System.Web.Http;

namespace Sfiss.ExerciseAPIService.Request
{
    [ServiceRequestActionFilter]
    public class RequestController : ApiController
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
