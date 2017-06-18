using System.Collections.Generic;

namespace ExerciseAPIService.Model
{
    public class SearchResponse
    {
        public ICollection<Entity> Data { get; set; }
    }
}