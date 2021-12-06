using EduApp.Core.Requests.User;
using EduApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EduApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] GetUserRequest userRequest)
        {
            try
            {
                var user = await _userService.GetUser(userRequest);

                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest userRequest)
        {
            try
            {
                var user = await _userService.UpdateUser(userRequest);

                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
