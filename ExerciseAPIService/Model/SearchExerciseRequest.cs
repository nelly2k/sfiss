using System.Collections.Generic;

namespace ExerciseAPIService.Model
{
    public class SearchExerciseRequest: SearchRequest
    {
        public ICollection<Muscle> Muscles { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
    }
}
