using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.Paging;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using AssmentCshap6.Data.EF;
using AssmentCshap6.Data.Entities;
using AssmentsCshap6.Application.SinhVienInMonHocs.RepositoryExtensions;
using Microsoft.EntityFrameworkCore;

namespace AssmentsCshap6.Application.SinhVienInMonHocs
{
    public class SinhvienInMonHocService : ISinhvienInMonHocService
    {
        private readonly AsmentCshap6Context _context;

        public SinhvienInMonHocService(AsmentCshap6Context context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> CreateSinhVienInMonHoc(CreatSinhVienInMonHoc svimh)
        {
            var idsinhvien = _context.Students.Where(c => c.Email == svimh.email).Select(c => c.Id).FirstOrDefault();
            if (idsinhvien == Guid.Empty)
            {
                return new ApiErrorResult<bool>("Không tìm thấy Sinh Viên!");
            }
            if (string.IsNullOrEmpty(svimh.tenmonhoc))
            {
                return new ApiErrorResult<bool>("Vui lòng chọn môn học để đỡ bị null !");
            }
            var idmonhoc = _context.Monhocs.Where(c => c.TenMonhoc == svimh.tenmonhoc).Select(c => c.IdMonhoc).FirstOrDefault();
            if (idmonhoc == null)
            {
                return new ApiErrorResult<bool>("Không tìm thấy Môn Học !");
            }
            var query = from p in _context.SinhVien_MonHocs
                        join pt in _context.Students on p.StudenId equals pt.Id
                        join pic in _context.Monhocs on p.MaMonHoc equals pic.IdMonhoc
                        select new { p, pt, pic };

            var result = query.Any(c => c.p.StudenId.Equals(idsinhvien) && c.p.MaMonHoc.Equals(idmonhoc));
            if (result)
            {
                return new ApiErrorResult<bool>("Sinh Viên Đã Được Thêm Vào Lớp Rồi !");
            }
            var svimh2 = new SinhVien_MonHoc()
            {
                StudenId = idsinhvien,
                MaMonHoc = idmonhoc,
                Diem = svimh.diem
            };
            _context.SinhVien_MonHocs.Add(svimh2);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool> { IsSuccessed = true, Message = "Tạo Mới Thành Công" };
        }

        public async Task<int> DeleteSinhVienInMonHoc(Guid idsv, int idmonhoc)
        {
            var svmhud = _context.SinhVien_MonHocs.Where(c => c.StudenId == idsv && c.MaMonHoc == idmonhoc).FirstOrDefault();
            if (svmhud == null)
            {
                throw new Exception();
            }
            _context.SinhVien_MonHocs.Remove(svmhud);
            return await _context.SaveChangesAsync();
        }

        public async Task<SinhVienINMonHocViewModel> GetSinhVienInMonHoc(Guid masv, int id )
        {
            var query = from p in _context.SinhVien_MonHocs
                        join pt in _context.Students on p.StudenId equals pt.Id
                        join pic in _context.Monhocs on p.MaMonHoc equals pic.IdMonhoc
                        where p.MaMonHoc == id && p.StudenId == masv
                        select new { p, pt, pic };

            var svmh = await query.FirstOrDefaultAsync(x=>x.p.MaMonHoc.Equals(id) && x.p.StudenId.Equals(masv));

            var data = new SinhVienINMonHocViewModel()
            {
                IdSrudent = svmh.pt.Id,
                IdMonhoc = svmh.pic.IdMonhoc,
                TenMonHoc = svmh.pic.TenMonhoc,
                TenSV = svmh.pt.HovsTenDem + " " + svmh.pt.Ten,
                Email = svmh.pt.Email,
                Diem = svmh.p.Diem
            };

            return data;
        }

        public async Task<PagedList<SinhVienINMonHocViewModel>> GetSinhVienInMonHocs(Parameters svimhParameters)
        {
            //1. Select join
            var query = from p in _context.SinhVien_MonHocs
                        join pt in _context.Students on p.StudenId equals pt.Id
                        join pic in _context.Monhocs on p.MaMonHoc equals pic.IdMonhoc
                        select new { p, pt, pic };
            
            var data = await query
                .Select(x => new SinhVienINMonHocViewModel()
                {
                    IdSrudent = x.pt.Id,
                    IdMonhoc = x.pic.IdMonhoc,
                    TenMonHoc = x.pic.TenMonhoc,
                    TenSV = x.pt.HovsTenDem + " " + x.pt.Ten,
                    Email = x.pt.Email,
                    Diem = x.p.Diem
                }).ToListAsync();
            ////2. filter
            if (!string.IsNullOrEmpty(svimhParameters.SearchTerm))
                data = await query
                .Select(x => new SinhVienINMonHocViewModel()
                {
                    IdSrudent = x.pt.Id,
                    IdMonhoc = x.pic.IdMonhoc,
                    TenMonHoc = x.pic.TenMonhoc,
                    TenSV = x.pt.HovsTenDem + " " + x.pt.Ten,
                    Email = x.pt.Email,
                    Diem = x.p.Diem
                }).Search(svimhParameters.SearchTerm).ToListAsync();
            return PagedList<SinhVienINMonHocViewModel>.ToPagedList(data, svimhParameters.PageNumber, svimhParameters.PageSize);
        }

        public async Task<ApiResult<bool>> UpdateSinhVienInMonHoc(Guid idsv,int idmonhoc, SinhVienINMonHocViewModel svimh)
        {
            var svmhud = _context.SinhVien_MonHocs.Where(c => c.StudenId == idsv && c.MaMonHoc == idmonhoc).FirstOrDefault();
            if(svmhud == null)
            {
                return new ApiErrorResult<bool>("Không Tìm Thấy Sinh Viên Trong Lớp Này !");
            }
    
            svmhud.Diem = svimh.Diem;
            _context.Update(svmhud);
            var result = await _context.SaveChangesAsync();
            if(result >= 1)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }
    }
}
