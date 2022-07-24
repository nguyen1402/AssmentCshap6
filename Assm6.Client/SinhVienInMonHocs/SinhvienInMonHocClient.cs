using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using Assm6.Client.Features;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Assm6.Client.SinhVienInMonHocs
{
    public class SinhvienInMonHocClient : ISinhvienInMonHocClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public SinhvienInMonHocClient(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<ApiResult<bool>> CreateSinhVienInMonHoc(CreatSinhVienInMonHoc svimh)
        {
            var content = System.Text.Json.JsonSerializer.Serialize(svimh);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("SinhVienInMonHocs", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (postResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(postContent);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(postContent);
        }

        public async Task<bool> DeleteSinhVienInMonHoc(Guid idsv, int idmh)
        {
            var url = Path.Combine("SinhVienInMonHocs", idsv.ToString(), idmh.ToString());

            var response = await _client.DeleteAsync(url);
            //var deleteResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<SinhVienINMonHocViewModel> GetSinhVienInMonHoc(Guid idsv, int idmh)
        {
            var url = Path.Combine("SinhVienInMonHocs", idsv.ToString(), idmh.ToString());

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var svmh = System.Text.Json.JsonSerializer.Deserialize<SinhVienINMonHocViewModel>(content, _options);
            return svmh;
        }

        public async Task<PagingResponse<SinhVienINMonHocViewModel>> GetSinhVienInMonHocs(Parameters svimhParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = svimhParameters.PageNumber.ToString(),
                ["searchTerm"] = svimhParameters.SearchTerm == null ? "" : svimhParameters.SearchTerm,
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("SinhVienInMonHocs", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<SinhVienINMonHocViewModel>
            {
                Items = System.Text.Json.JsonSerializer.Deserialize<List<SinhVienINMonHocViewModel>>(content, _options),
                MetaData = System.Text.Json.JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }

        public async Task<ApiResult<bool>> UpdateSinhVienInMonHoc(Guid idsv, int idmh, SinhVienINMonHocViewModel svimh)
        {
            var content = System.Text.Json.JsonSerializer.Serialize(svimh);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("SinhVienInMonHocs", idsv.ToString(), idmh.ToString());
            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (postResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(postContent);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(postContent);
        }
    }
}
