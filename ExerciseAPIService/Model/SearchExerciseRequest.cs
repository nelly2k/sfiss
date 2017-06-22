using System.Collections.Generic;
using ExerciseAPIService.Constant;
using Sfiss.Common.Database;

namespace ExerciseAPIService.Model
{
    public class SearchExerciseRequest: SearchRequest
    {
        public SearchExerciseRequest()
        {
            Muscles = new List<Muscle>();
            Equipments = new List<Equipment>();
            Types = new List<ExerciseType>();
            Complexity = new List<Complexity>();
            Areas = new List<Area>();
        }
        public ICollection<Muscle> Muscles { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<ExerciseType> Types { get; set; }
        public ICollection<Complexity> Complexity { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
