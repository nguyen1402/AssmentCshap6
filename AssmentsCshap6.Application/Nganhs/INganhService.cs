using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.Nganhs;
using AsmentCShap6.ViewModels.Paging;
using AsmentCShap6.ViewModels.RequestFeatures;
using AssmentCshap6.Data.Entities;

namespace AssmentsCshap6.Application.Nganhs
{
    public interface INganhService
    {
        Task<PagedList<Nganh>> GetNganhs(Parameters nganhParameters);
        Task<ApiResult<bool>> CreateNganh(CreatNganh nganh);
        Task<Nganh> GetNganh(int id);
        Task<ApiResult<bool>> UpdateNganh(UpdateNganhs nganh , Nganh dbnganh);
        Task DeleteNganh(Nganh nganhdelete);
    }
}
