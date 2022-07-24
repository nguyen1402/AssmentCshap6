using AsmentCShap6.ViewModels.MonHocs;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.Schools;
using AssmentsCshap6.Application.Monhocs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AssmentCshap6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonhocsController : ControllerBase
    {
        private readonly IMonHocService _repo;

        public MonhocsController(IMonHocService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameters monhocParameters)
        {
            var nganhs = await _repo.GetMonHocs(monhocParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(nganhs.MetaData));

            return Ok(nganhs);
        }

        [HttpGet("allmonhoc")]
        public async Task<IActionResult> GetAllMonHoc()
        {
            var nganhs = await _repo.GetlsMonhocs();

            return Ok(nganhs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMonHoc([FromBody] CreatMonHoc monhoc)
        {
            if (monhoc == null)
                return BadRequest();

            var kq = await _repo.CreateMonHoc(monhoc);
            if (string.IsNullOrEmpty(kq.Message))
            {
                return BadRequest(kq);
            }

            return Ok(kq);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonHoc(int id)
        {
            var nganh = await _repo.GetMonHoc(id);
            return Ok(nganh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMonHoc(int id, [FromBody] UpdateMonHoc monhoc)
        {
            //additional product and model validation checks

            var dbmonhoc = await _repo.GetMonHoc(id);
            if (dbmonhoc == null)
                return NotFound();

            var kq = await _repo.UpdateMonHoc(monhoc, dbmonhoc);

            if (string.IsNullOrEmpty(kq.Message))
            {
                return BadRequest(kq);
            }

            return Ok(kq);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHoc(int id)
        {
            var monhoc = await _repo.GetMonHoc(id);
            if (monhoc == null)
                return NotFound();

            await _repo.DeleteMonHoc(monhoc);

            return NoContent();
        }
    }
}
