using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices UserService;
        public UserController(IUserServices userService)
        {
            UserService = userService;
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User newUser)
        {
            UserService.AddUser(newUser);
            return Ok();
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {

            return Ok(UserService.GetUser());
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User userToUpdate, int id)
        {
            UserService.UpdateUser(userToUpdate, id);
            return Ok();
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            UserService.DeleteUser(id);
            return Ok();
        }
    }
}
