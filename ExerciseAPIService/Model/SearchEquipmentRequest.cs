using Sfiss.Common.Database;

namespace ExerciseAPIService.Model
{
    public class SearchEquipmentRequest:SearchRequest
    {
        public int? ExerciseId { get; set; }
    }
}