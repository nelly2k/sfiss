using System.Collections.Generic;
using Sfiss.Common.Database;

namespace Sfiss.ExerciseAPIService.Muscle
{
    public class SearchMuscleRequest : SearchRequest
    {
        public int? ExerciseId { get; set; }
        public IEnumerable<Area> Areas { get; set; }
    }
}
