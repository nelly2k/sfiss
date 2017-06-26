using System.Web.Http;
using Sfiss.Common.Model;

namespace Sfiss.ExerciseAPIService.Equipment
{
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        public PaginationResult<Equipment> Post([FromBody] SearchEquipmentRequest request)
        {
            return _equipmentService.Search(request);
        }
    }
}
