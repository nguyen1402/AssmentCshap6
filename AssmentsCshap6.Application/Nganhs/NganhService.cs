using AsmentCShap6.ViewModels.Nganhs;
using AssmentCshap6.Data.EF;
using AssmentsCshap6.Application.Nganhs.RepositoryExtensions;
using Microsoft.EntityFrameworkCore;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.Monhocs.RepositoryExtensions;
using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.Paging;
using AsmentCShap6.ViewModels.RequestFeatures;

namespace AssmentsCshap6.Application.Nganhs
{
    public class NganhService : INganhService
    {
        private readonly AsmentCshap6Context _context;

        public NganhService(AsmentCshap6Context context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> CreateNganh(CreatNganh nganh)
        {
            var tennganh = _context.Nganhs.Any(c => c.TenNganh == nganh.TenNganh);
            if (tennganh)
            {
                return new ApiErrorResult<bool>("Tên ngành học đã tồn tại !");
            }
            var nganhs = new Nganh
            {
                TenNganh = nganh.TenNganh
            };
            _context.Nganhs.Add(nganhs);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool> { IsSuccessed = true, Message = "Tạo Mới Thành Công" };
        }

        public async Task DeleteNganh(Nganh nganhdelete)
        {
            _context.Remove(nganhdelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Nganh> GetNganh(int id)
        {
           return await _context.Nganhs.FirstOrDefaultAsync(p => p.IdNganh.Equals(id));
        }

        public async Task<PagedList<Nganh>> GetNganhs(Parameters nganhParameters)
        {
            var nganhs = await _context.Nganhs.Search(nganhParameters.SearchTerm)
                .ToListAsync();

            return PagedList<Nganh>.ToPagedList(nganhs, nganhParameters.PageNumber, nganhParameters.PageSize);
        }

        public async Task<ApiResult<bool>> UpdateNganh(UpdateNganhs nganh, Nganh dbnganh)
        {
            var tennganh = _context.Nganhs.Any(c => c.TenNganh == nganh.TenNganh);
            if (tennganh)
            {
                return new ApiErrorResult<bool>("Tên ngành học đã tồn tại !");
            }
            dbnganh.TenNganh = nganh.TenNganh;
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool> { IsSuccessed = true, Message = "Cập Nhật Thành Công" };
        }
    }
}
