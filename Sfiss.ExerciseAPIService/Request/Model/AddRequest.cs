using System;
using System.Collections.Generic;
using Sfiss.Common.Model;
using Sfiss.ExerciseAPIService.Exercise;

namespace Sfiss.ExerciseAPIService.Request
{
    public class AddRequest:Entity
    {
        public Complexity? Complexity { get; set; }
        public Guid CreatedBy { get; set; }
        public IEnumerable<Muscle.Muscle> Muscles { get; set; }
        public IEnumerable<Equipment.Equipment> Equipments { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public string Notes { get; set; }

        public string OtherTitles { get; set; }
    }
}