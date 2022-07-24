using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.Paging;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using AssmentCshap6.Data.Entities;

namespace AssmentsCshap6.Application.SinhVienInMonHocs
{
    public interface ISinhvienInMonHocService
    {
        Task<PagedList<SinhVienINMonHocViewModel>> GetSinhVienInMonHocs(Parameters svimhParameters);
        Task<ApiResult<bool>> CreateSinhVienInMonHoc(CreatSinhVienInMonHoc svimh);
        Task<SinhVienINMonHocViewModel> GetSinhVienInMonHoc(Guid masv, int id);
        Task<ApiResult<bool>> UpdateSinhVienInMonHoc(Guid idsv, int idmonhoc, SinhVienINMonHocViewModel svimh);
        Task<int> DeleteSinhVienInMonHoc(Guid idsv, int idmonhoc);
    }
}
