using AsmentCShap6.ViewModels.Nganhs;
using AsmentCShap6.ViewModels.RequestFeatures;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.Nganhs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AssmentCshap6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NganhsController : ControllerBase
    {
        private readonly INganhService _repo;

        public NganhsController(INganhService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameters nganhParameters)
        {
            var nganhs = await _repo.GetNganhs(nganhParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(nganhs.MetaData));

            return Ok(nganhs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNganh([FromBody] CreatNganh nganh)
        {
            if (nganh == null)
                return BadRequest();

           var kq = await _repo.CreateNganh(nganh);

            if (string.IsNullOrEmpty(kq.Message))
            {
                return BadRequest(kq);
            }

            return Ok(kq);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNganh(int id)
        {
            var nganh = await _repo.GetNganh(id);
            return Ok(nganh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateNganhs nganh)
        {
            //additional product and model validation checks

            var dbNganh = await _repo.GetNganh(id);
            if (dbNganh == null)
                return NotFound();

            var kq = await _repo.UpdateNganh(nganh, dbNganh);

            if (string.IsNullOrEmpty(kq.Message))
            {
                return BadRequest(kq);
            }

            return Ok(kq);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNganh(int id)
        {
            var nganh = await _repo.GetNganh(id);
            if (nganh == null)
                return NotFound();

            await _repo.DeleteNganh(nganh);

            return NoContent();
        }
    }
}
