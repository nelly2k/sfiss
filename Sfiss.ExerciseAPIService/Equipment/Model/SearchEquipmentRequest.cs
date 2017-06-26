using Sfiss.Common.Database;

namespace Sfiss.ExerciseAPIService.Equipment
{
    public class SearchEquipmentRequest : SearchRequest
    {
        public int? ExerciseId { get; set; }
    }
}