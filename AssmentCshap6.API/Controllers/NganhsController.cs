using AssmentsCshap6.Application.Nganh;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssmentCshap6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NganhsController : ControllerBase
    {
        private readonly INganh _iNganh;

        public NganhsController(INganh iNganh)
        {
            _iNganh = iNganh;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var nganhs = await _iNganh.GetAll();
            return Ok(nganhs);
        }
    }
}
