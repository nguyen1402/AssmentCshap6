using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.Schools;
using Assm6.Client.Features;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Assm6.Client.MonHocs
{
    public class MonhocClient : IMonhocClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public MonhocClient(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<ApiResult<bool>> CreateMonhoc(CreatMonHoc monhoc)
        {
            var content = System.Text.Json.JsonSerializer.Serialize(monhoc);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("Monhocs", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (postResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(postContent);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(postContent);
        }

        public async Task DeleteMonhoc(int id)
        {
            var url = Path.Combine("Monhocs", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

        public async Task<List<Monhoc>> GetlsMonhocs()
        {
            var url = Path.Combine("Monhocs/allmonhoc");

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var monhoc = System.Text.Json.JsonSerializer.Deserialize<List<Monhoc>>(content, _options);
            return monhoc;
        }

        public async Task<Monhoc> GetMonhoc(int id)
        {
            var url = Path.Combine("Monhocs", id.ToString());

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var monhoc = System.Text.Json.JsonSerializer.Deserialize<Monhoc>(content, _options);
            return monhoc;
        }

        public async Task<PagingResponse<Monhoc>> GetMonhocs(Parameters nganhParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = nganhParameters.PageNumber.ToString(),
                ["searchTerm"] = nganhParameters.SearchTerm == null ? "" : nganhParameters.SearchTerm,
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("Monhocs", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Monhoc>
            {
                Items = System.Text.Json.JsonSerializer.Deserialize<List<Monhoc>>(content, _options),
                MetaData = System.Text.Json.JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }

        public async Task<ApiResult<bool>> UpdateMonhoc(Monhoc monhoc)
        {
            var content = System.Text.Json.JsonSerializer.Serialize(monhoc);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Monhocs", monhoc.IdMonhoc.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (postResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(postContent);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(postContent);
        }
    }
}
