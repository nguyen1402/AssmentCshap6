using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.Schools;
using Assm6.Client.Features;
using AssmentCshap6.Data.Entities;

namespace Assm6.Client.MonHocs
{
    public interface IMonhocClient
    {

        Task<PagingResponse<Monhoc>> GetMonhocs(Parameters nganhParameters);
        Task<ApiResult<bool>> CreateMonhoc(CreatMonHoc monhoc);
        Task<Monhoc> GetMonhoc(int id);
        Task<ApiResult<bool>> UpdateMonhoc(Monhoc monhoc);
        Task DeleteMonhoc(int id);
        Task<List<Monhoc>> GetlsMonhocs();
    }
}
