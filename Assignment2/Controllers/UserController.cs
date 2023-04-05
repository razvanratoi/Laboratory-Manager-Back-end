using Assignment1.Services;
using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("create/{userId}")]
        public IActionResult CreateStudent([FromRoute] int userId,  [FromBody] string email)
        {
            if(_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
            var token = _userService.CreateStudent(email);
            return Ok(token);
            }else return BadRequest("Teacher only operation!");
        }

        [HttpPost]
        public IActionResult RegisterStudent([FromRoute] int userId, [FromBody] Credentials creds)
        {
            var res = _userService.Register(creds);
            if(res == false)
                return BadRequest();
            else 
                return Ok(creds);
        }

        [HttpDelete("/{userId}")]
        public IActionResult DeleteUser([FromRoute] int userId, [FromBody] string email)
        {
            if(_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
            var res = _userService.DeleteUser(email);
            if(res)
                return Ok(email);
            else
                return BadRequest();
            }else return BadRequest("Teacher only operation!");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginCredentials creds)
        {
            var res = _userService.Login(creds);
            if(res == null)
                return BadRequest();
            else 
                return Ok(res);
        }

        [HttpPost("createTeacher")]
        public IActionResult CreateTeacher([FromRoute] int userId,  [FromBody] User user)
        {
            var token = _userService.CreateTeacher(user);
            return Ok(token);
        }

        //update user
        [HttpPut("{userId}")]
        public IActionResult UpdateUser([FromRoute] int userId, [FromBody] User user)
        {
            if(_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
            var res = _userService.UpdateUser(user);
            if(res == null)
                return BadRequest();
            else 
                return Ok(res);
           }else return BadRequest("Teacher only operation!");
        }
    }
}