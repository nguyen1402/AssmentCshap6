using Assm6.Client.BaseAPI;
using AssmentCshap6.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Assm6.Client.Schools
{
    public class SchoolClient : BaseApiClient,ISchoolClient
    {
        protected SchoolClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<SchoolVM>> GetAll()
        {
            return await GetListAsync<SchoolVM>("/api/Schools");
        }
    }
}
