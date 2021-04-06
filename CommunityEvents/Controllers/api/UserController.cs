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
                UserId = 0,
                Username = "Eric",
                Password = "Shoemaker",
                Email = "shoemaker30@marshall.edu",
                HomeZip = 25510
            }
            
        };

        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            var userList = new List<User>();
            userList.AddRange(users);
            return userList;
        }

        // GET api/<controller>/5
        public User Get(String username, String password)
        {
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
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