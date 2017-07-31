using System;

namespace Sfiss.WorkoutAPIService.Model
{
    public class WorkoutSearchResultItem
    {
        public Guid Grid { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}