using AssmentCshap6.Data.ViewModels;
using AssmentsCshap6.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssmentCshap6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;
        public UsersController(IUsers users)
        {
            _users = users;
        }
        [HttpPost("Authencate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authencate([FromBody] Loginrequest loginrequest)
        {
            if (!ModelState.IsValid) return BadRequest();
            var resualToken = await _users.Authencate(loginrequest);
            if (string.IsNullOrEmpty(resualToken.Token))
            {
                return BadRequest(resualToken);
            }
            return Ok(resualToken);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] Registerequest registerrequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var resual = await _users.Register(registerrequest);
            if (!resual.IsSuccessed)
            {
                return BadRequest(resual);
            }
            return Ok(resual);
        }
    }
}
