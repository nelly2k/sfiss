using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using ExerciseAPIService.Model;
using System.Fabric;

namespace ExerciseAPIService.Service
{
    public interface IExerciseSearchService
    {
        SearchResponse Search(SearchRequest request);
    }

    public class ExerciseSearchService : IExerciseSearchService
    {
        
        public SearchResponse Search(SearchRequest request)
        {


            return new SearchResponse()
            {
                Data = new List<Entity>()
                {
                    new Entity()
                    {
                        Id = 10,
                        Title = "Bench Press"

                    }
                }
            };
        }
    }
}