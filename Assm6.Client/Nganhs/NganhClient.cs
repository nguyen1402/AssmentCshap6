using Assm6.Client.BaseAPI;
using AssmentCshap6.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Assm6.Client.Nganhs
{
    public class NganhClient : BaseApiClient,INganhClient
    {
        protected NganhClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<NganhVM>> GetAll()
        {
            return await GetListAsync<NganhVM>("/api/Schools");
        }
    }
}
