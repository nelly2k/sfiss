using System.Collections.Generic;
using Sfiss.Common.Database;
using Sfiss.ExerciseAPIService.Muscle;

namespace Sfiss.ExerciseAPIService.Exercise
{
    public class SearchExerciseRequest : SearchRequest
    {
        public SearchExerciseRequest()
        {
            Muscles = new List<Muscle.Muscle>();
            Equipments = new List<Equipment.Equipment>();
            Types = new List<ExerciseType>();
            Complexity = new List<Complexity>();
            Areas = new List<Area>();
        }
        public ICollection<Muscle.Muscle> Muscles { get; set; }
        public ICollection<Equipment.Equipment> Equipments { get; set; }
        public ICollection<ExerciseType> Types { get; set; }
        public ICollection<Complexity> Complexity { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}