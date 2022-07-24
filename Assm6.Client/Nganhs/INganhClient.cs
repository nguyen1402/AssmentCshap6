using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.Nganhs;
using AsmentCShap6.ViewModels.RequestFeatures;
using Assm6.Client.Features;
using AssmentCshap6.Data.Entities;

namespace Assm6.Client.Nganhs
{
    public interface INganhClient
    {
        Task<PagingResponse<Nganh>> GetNganhs(Parameters nganhParameters);
        Task<ApiResult<bool>> CreateNganh(CreatNganh nganh);
        Task<Nganh> GetNganh(int id);
        Task<ApiResult<bool>> UpdateNganh(Nganh nganh);
        Task DeleteNganh(int id);
        Task<string> UploadProductImage(MultipartFormDataContent content);
    }
}
