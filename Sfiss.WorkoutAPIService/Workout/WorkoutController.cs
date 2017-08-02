using System;
using System.Web.Http;

namespace Sfiss.WorkoutAPIService.Workout
{
    public class WorkoutController:ApiController
    {
        private readonly IExerciseService _exerciseService;

        public WorkoutController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        public string Get(Guid id)
        {
            _exerciseService.Get();
            return "value";
        }

        // POST api/values 
        public Guid Post(Guid? guid)
        {
            if (guid != null)
            {
                //create new
            }
            else
            {
                //cope existisng
            }
            //Adds new workout placeholder, returns guid
            return new Guid();
        }

        // PUT api/values/5 
        public void Put(Guid guid, string field, object value)
        {
            //updates value
        }

        // DELETE api/values/5 
        public void Delete(Guid guid)
        {
            //deletes workout
        }
    }
}