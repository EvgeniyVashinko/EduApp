using EduApp.Core.Requests;
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

        public AccountController(IJwtService jwtService, IAccountService accountService)
        {
            _jwtService = jwtService;
            _accountService = accountService;
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
    }
}
