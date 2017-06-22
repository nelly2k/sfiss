using System;
using System.Web.Http;
using ExerciseAPIService.Model;
using ExerciseAPIService.Service;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Controllers
{
    public class EquipmentController:ApiController
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