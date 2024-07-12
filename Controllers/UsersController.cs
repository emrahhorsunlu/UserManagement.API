using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using UserManagement.API.Fake;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id) 
        { 
            var user = _users.FirstOrDefault(x=> x.Id == id);
            return user;
        }

        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x=>x.Id == user.Id);
            editedUser.FirstName = user.FirstName; 
            editedUser.LastName = user.LastName;
            editedUser.Adress = user.Adress;
            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x=> x.Id == id);
            _users.Remove(deletedUser);
        }


    }
}
