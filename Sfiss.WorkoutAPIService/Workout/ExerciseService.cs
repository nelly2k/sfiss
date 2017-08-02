using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sfiss.Common.Communication;
using Sfiss.Common.Contract;
using Sfiss.Common.Model;
using Sfiss.WorkoutAPIService.Workout.Model;

namespace Sfiss.WorkoutAPIService.Workout
{
    public interface IExerciseService:IService
    {
        Task<IEnumerable<Entity>> Get();
    }

    public class ExerciseService : IExerciseService
    {
        private readonly ICommunication _communication;

        public ExerciseService(ICommunication communication)
        {
            _communication = communication;
        }
        public async Task<IEnumerable<Entity>> Get()
        {
            using (var client = _communication.GetClientFor(Service.Exercise))
            {
                var path = "api/exercise";
                var request = new SearchExerciseRequest()
                {
                    Ids = new List<int>() { 1, 2 }
                };
                var response = await client.PostAsJsonAsync(path, request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<PaginationResult<Entity>>();
                return result.Data;
            }
           
        }
    }
}
