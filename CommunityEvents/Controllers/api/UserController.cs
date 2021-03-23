using System;
using CommunityEvents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommunityEvents.Controllers.api
{
    public class UserController : ApiController
    {
        List<User> users = new List<User>()
        {
            new User()
            {
                Username = "Eric",
                Password = "Shoemaker"
                
            }
            
        };

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(String username, String password)
        {
            return 
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}