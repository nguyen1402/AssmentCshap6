using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using Assm6.Client.Features;

namespace Assm6.Client.SinhVienInMonHocs
{
    public interface ISinhvienInMonHocClient
    {
        Task<PagingResponse<SinhVienINMonHocViewModel>> GetSinhVienInMonHocs(Parameters svimhParameters);
        Task<ApiResult<bool>> CreateSinhVienInMonHoc(CreatSinhVienInMonHoc svimh);
        Task<SinhVienINMonHocViewModel> GetSinhVienInMonHoc(Guid idsv, int idmh);
        Task<ApiResult<bool>> UpdateSinhVienInMonHoc(Guid idsv, int idmh, SinhVienINMonHocViewModel svimh);
        Task<bool> DeleteSinhVienInMonHoc(Guid idsv,int idmh);
    }
}
