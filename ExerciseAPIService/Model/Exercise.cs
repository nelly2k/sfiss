using System.Collections.Generic;
using ExerciseAPIService.Constant;

namespace ExerciseAPIService.Model
{
    public class Exercise: ExerciseBrief
    {
        public string Notes { get; set; }
    }

    public class ExerciseBrief : Entity
    {
        public string OtherTitles { get; set; }
        public Complexity? Complexity { get; set; }
        public IEnumerable<Muscle> Muscles { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
        public ExerciseType ExerciseType { get; set; }
    }
}