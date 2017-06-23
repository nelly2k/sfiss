using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Sfiss.WorkoutAPIService.Controllers
{
    public class FavoriteController:ApiController
    {
        // POST api/values 
        public void Post([FromBody]Guid guid)
        {
        }

   
        // DELETE api/values/5 
        public void Delete(Guid guid)
        {
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}