using System.Collections.Generic;
using ExerciseAPIService.Constant;
using Sfiss.Common.Database;

namespace ExerciseAPIService.Model
{
    public class SearchMuscleRequest: SearchRequest
    {
        public int? ExerciseId { get; set; }
        public IEnumerable<Area> Areas { get; set; }
    }
}