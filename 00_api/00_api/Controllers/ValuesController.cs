using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _00_api.Controllers
{
    public class ValuesController : ApiController
    {
        // static data 
        static List<string> str = new List<string>()
        {
            "01 Banana ", "02 Tomator", "03 Onion"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return str; // return all strings
        }

        // GET api/values/5
        public string Get(int id)
        {
            return str[id]; // should return the id value
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            str.Add(value);  // should add the all value  in autoincrementable 
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            str[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            str.RemoveAt(id);
        }
    }
}
