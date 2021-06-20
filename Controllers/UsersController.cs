using Microsoft.AspNetCore.Mvc;
using MyKoloApi.DTOs;
using MyKoloApi.Services;

namespace MyKoloApi.Controllers
{
    [ApiController]
    [Route("User")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult SignUp([FromBody]RegisterUserDto model)
        {
            var register = _userService.SignUp(model);

            if (register)
            {
                return Ok(new {message = "Registration successful"});
            }
            else
            {
                return BadRequest(new {message = "User already exist"});
            }
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult Login([FromBody]LoginUserDto model)
        {
            var signedInUser = _userService.LogIn(model);

            if (signedInUser == null)
            {
                return BadRequest(new {message = "Sign-In failed"});
            }
            else
            {
                return Ok(signedInUser);
            }
        }
    }
}