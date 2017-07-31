using System;

namespace Sfiss.WorkoutAPIService.Model
{
    public class Completion
    {
        public double? Distance { get; set; }

        public DateTime? Duration { get; set; }

        public int?  Repeats { get; set; } 
    }
}