using System;

namespace Sfiss.WorkoutAPIService.Model
{
    public class SectionExercise
    {
        public Guid SectionGuid { get; set; }
        public int ExerciseId { get; set; }

        public int Sets { get; set; }

        public Completion Completion { get; set; }
    }
}