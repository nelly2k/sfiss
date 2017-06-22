using System;

namespace ExerciseAPIService.Model
{
    public class AddRequest: Exercise
    {
        public Guid CreatedBy { get; set; }
    }
}