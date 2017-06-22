using System.Collections.Generic;
using ExerciseAPIService.Constant;
using Sfiss.Common.Database;

namespace ExerciseAPIService.Model
{
    public class SearchExerciseRequest: SearchRequest
    {
        public ICollection<Muscle> Muscles { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<ExerciseType> Types { get; set; }
        public ICollection<Complexity> Complexity { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
