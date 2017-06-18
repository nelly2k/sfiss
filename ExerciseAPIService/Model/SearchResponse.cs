using System.Collections.Generic;

namespace ExerciseAPIService.Model
{
    public class SearchResponse
    {
        public IEnumerable<Entity> Data { get; set; }
    }
}