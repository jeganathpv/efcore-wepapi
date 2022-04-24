using Microsoft.AspNetCore.Mvc;
using WebApiEFCore.BusinessObjects;
using WebApiEFCore.Models;
using WebApiEFCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.userService.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return this.userService.GetUserById(id);
        }

        [HttpGet("available/{email}")]
        public UserResponse GetUserDetail(string email)
        {
            return this.userService.GetUserDetailByEmailId(email);
        }

        // POST api/<UserController>
        [HttpPost("addUser")]
        public User AddUser([FromBody] User value)
        {
            return this.userService.AddUser(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("update/{id}")]
        public bool UpdateUser(string id, [FromBody] User value)
        {
            return this.userService.UpdateUser(id, value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("delete/{id}")]
        public bool Delete(string id)
        {
            return this.userService.DeleteUser(id);
        }
    }
}
