using System;

namespace Sfiss.WorkoutAPIService.Model
{
    public class Workout
    {
        public Guid Grid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}