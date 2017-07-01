﻿using System.Collections.Generic;
using Sfiss.Common.Model;

namespace Sfiss.ExerciseAPIService.Exercise
{
    public class Exercise : ExerciseBrief
    {
        public string Notes { get; set; }
    }

    public class ExerciseBrief : Entity
    {
        public string OtherTitles { get; set; }
        public Complexity? Complexity { get; set; }
        public IEnumerable<Muscle.Muscle> Muscles { get; set; }
        public IEnumerable<Equipment.Equipment> Equipments { get; set; }
        public ExerciseType ExerciseType { get; set; }
    }
}