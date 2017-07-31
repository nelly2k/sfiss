using System;
using System.Collections.Generic;

namespace Sfiss.WorkoutAPIService.Workout.Model
{
    public class Workout
    {
        public Guid Grid { get; set; }
        public string Title { get; set; }
        public IEnumerable<Sfiss.WorkoutAPIService.Model.Section> Sections { get; set; }
    }
}
