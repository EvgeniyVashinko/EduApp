using EduApp.Core.Requests;
using EduApp.Core.Requests.User;
using EduApp.Core.Responses;
using EduApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IJwtService jwtService, IAccountService accountService, IUserService userService)
        {
            _jwtService = jwtService;
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var account = await _accountService.GetAccountPermissionsOrDefault(request);

                if (account is not null)
                {
                    var jwt = _jwtService.GetJwt(account.Claims);

                    var response = new AuthenticationResponse()
                    {
                        Token = jwt,
                        AccountId = account.AccountId
                    };

                    return Ok(response);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Unauthorized();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] CreateUserRequest request)
        {
            try
            {
                await _userService.CreateUser(request);

                var account = await _accountService.GetAccountPermissionsOrDefault(new()
                {
                    Username = request.Username,
                    Password = request.Password
                });

                var jwt = _jwtService.GetJwt(account.Claims);

                var response = new AuthenticationResponse()
                {
                    Token = jwt,
                    AccountId = account.AccountId
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
