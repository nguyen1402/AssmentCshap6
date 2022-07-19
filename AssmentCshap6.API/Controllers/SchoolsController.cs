using AssmentsCshap6.Application.Schools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssmentCshap6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly Ischool _ischool;

        public SchoolsController(Ischool ischool)
        {
            _ischool   = ischool;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var schools = await _ischool.GetAll();
            return Ok(schools);
        }
    }
}
