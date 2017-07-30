using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sfiss.MediaAPIService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
       
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Guid Post([FromBody]string value)
        {
            return Guid.NewGuid();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
