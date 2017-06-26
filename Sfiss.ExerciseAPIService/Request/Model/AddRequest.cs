using System;

namespace Sfiss.ExerciseAPIService.Request
{
    public class AddRequest : Exercise.Exercise
    {
        public Guid CreatedBy { get; set; }
    }
}