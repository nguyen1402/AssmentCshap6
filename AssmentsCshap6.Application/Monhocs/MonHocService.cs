using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.MonHocs;
using AsmentCShap6.ViewModels.Paging;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.Schools;
using AssmentCshap6.Data.EF;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.Monhocs.RepositoryExtensions;
using Microsoft.EntityFrameworkCore;

namespace AssmentsCshap6.Application.Monhocs
{
    public class MonHocService : IMonHocService
    {
        public readonly AsmentCshap6Context _context;
        public MonHocService(AsmentCshap6Context context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> CreateMonHoc(CreatMonHoc monhoc)
        {
            var tenmonhoc = _context.Monhocs.Any(c => c.TenMonhoc == monhoc.TenMonHoc);
            if (tenmonhoc)
            {
                return new ApiErrorResult<bool>("Tên môn học đã tồn tại !");
            }
            var monhocs = new Monhoc
            {
                TenMonhoc = monhoc.TenMonHoc,
                ImageUrl = monhoc.ImageUrl
            };
            _context.Monhocs.Add(monhocs);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool> { IsSuccessed = true, Message = "Tạo Mới Thành Công" };
        }

        public async Task DeleteMonHoc(Monhoc monhocdelete)
        {
            _context.Remove(monhocdelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Monhoc>> GetlsMonhocs()
        {
            return await _context.Monhocs.ToListAsync();
        }

        public async Task<Monhoc> GetMonHoc(int id)
        {
            return await _context.Monhocs.FirstOrDefaultAsync(c => c.IdMonhoc.Equals(id));
        }

        public async Task<PagedList<Monhoc>> GetMonHocs(Parameters monhocParameters)
        {
            var monhocs = await _context.Monhocs.Search(monhocParameters.SearchTerm).ToListAsync();
            return PagedList<Monhoc>.ToPagedList(monhocs, monhocParameters.PageNumber, monhocParameters.PageSize);

        }

        public async Task<ApiResult<bool>> UpdateMonHoc(UpdateMonHoc monhoc, Monhoc dbmonhoc)
        {
            var tenmonhoc = _context.Monhocs.Any(c => c.TenMonhoc == monhoc.TenMonHoc);
            if (tenmonhoc)
            {
                return new ApiErrorResult<bool>("Tên môn học đã tồn tại !");
            }
            dbmonhoc.TenMonhoc = monhoc.TenMonHoc;
            dbmonhoc.ImageUrl = monhoc.ImageUrl;

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool> { IsSuccessed = true, Message = "Cập Nhật Thành Công" };
        }
    }
}
