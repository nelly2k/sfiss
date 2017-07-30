using System.Collections.Generic;
using Sfiss.Common.Model;

namespace Sfiss.ExerciseAPIService.Exercise
{
    public class ExerciseDto:Entity
    {
        public string OtherTitles { get; set; }
        public Complexity Complexity { get; set; }
        public IEnumerable<Muscle.MuscleDto> Muscles { get; set; }
        public IEnumerable<Equipment.Equipment> Equipments { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public string Notes { get; set; }
    }

    public class Exercise : Entity
    {
        public string OtherTitles { get; set; }
        public string Complexity { get; set; }
        public IEnumerable<Muscle.Muscle> Muscles { get; set; }
        public IEnumerable<Equipment.Equipment> Equipments { get; set; }
        public string ExerciseType { get; set; }

        public string Notes { get; set; }
    }
}