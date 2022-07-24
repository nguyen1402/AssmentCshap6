using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.SinhVienInMonHocs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AssmentCshap6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienInMonHocsController : ControllerBase
    {
        private readonly ISinhvienInMonHocService _repo;

        public SinhVienInMonHocsController(ISinhvienInMonHocService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Parameters svimhParameters)
        {
            var svimhs = await _repo.GetSinhVienInMonHocs(svimhParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(svimhs.MetaData));

            return Ok(svimhs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSinhVienInMonHocs([FromBody] CreatSinhVienInMonHoc svimh)
        {
            if (svimh == null)
                return BadRequest();

            var kq =  await _repo.CreateSinhVienInMonHoc(svimh);
            if (string.IsNullOrEmpty(kq.Message))
            {
                return BadRequest(kq);
            }

            return Ok(kq);
        }

        [HttpGet("{svid}/{id}")]
        public async Task<IActionResult> GetSinhVienInMonHocs(Guid svid,int id)
        {
            var svmh = await _repo.GetSinhVienInMonHoc(svid,id);
            return Ok(svmh);
        }

        [HttpPut("{idsv}/{idmonhoc}")]
        public async Task<IActionResult> UpdateSinhVienInMonHoc(Guid idsv, int idmonhoc, [FromBody] SinhVienINMonHocViewModel svimh)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           var kq = await _repo.UpdateSinhVienInMonHoc(idsv, idmonhoc, svimh);

            if (string.IsNullOrEmpty(kq.Message))
            {
                return BadRequest(kq);
            }

            return Ok(kq);
        }

        [HttpDelete("{idsv}/{idmh}")]
        public async Task<IActionResult> DeleteNganh(Guid idsv, int idmh)
        {
            var kq = await _repo.DeleteSinhVienInMonHoc(idsv, idmh);

            if (kq == 0) return BadRequest();
            return Ok();
        }
    }
}
