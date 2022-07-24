using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.Nganhs;
using AsmentCShap6.ViewModels.RequestFeatures;
using Assm6.Client.Features;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Assm6.Client.Nganhs
{
    public class NganhClient : INganhClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public NganhClient(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<ApiResult<bool>> CreateNganh(CreatNganh nganh)
        {
            var content = System.Text.Json.JsonSerializer.Serialize(nganh);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("Nganhs", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (postResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(postContent);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(postContent);
        }

        public async Task DeleteNganh(int id)
        {
            var url = Path.Combine("Nganhs", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

        public async Task<Nganh> GetNganh(int id)
        {
            var url = Path.Combine("Nganhs", id.ToString());

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var nganh = System.Text.Json.JsonSerializer.Deserialize<Nganh>(content, _options);
            return nganh;
        }

        public async Task<PagingResponse<Nganh>> GetNganhs(Parameters nganhParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = nganhParameters.PageNumber.ToString(),
                ["searchTerm"] = nganhParameters.SearchTerm == null ? "" : nganhParameters.SearchTerm,
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("Nganhs", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Nganh>
            {
                Items = System.Text.Json.JsonSerializer.Deserialize<List<Nganh>>(content, _options),
                MetaData = System.Text.Json.JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }

        public async Task<ApiResult<bool>> UpdateNganh(Nganh nganh)
        {
            var content = System.Text.Json.JsonSerializer.Serialize(nganh);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Nganhs", nganh.IdNganh.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (postResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(postContent);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(postContent);
        }

        public async Task<string> UploadProductImage(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("Uploads", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("https://localhost:7249/", postContent);
                return imgUrl;
            }
        }
    }
}
