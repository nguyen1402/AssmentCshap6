using Assm6.Client.Nganhs;
using Assm6.Client.Shared;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class DeleteNganh
    {
        private Nganh _nganh;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        INganhClient _NganhClient { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _nganh = await _NganhClient.GetNganh(Convert.ToInt32(Id));
        }

        private async Task Delete()
        {
            await _NganhClient.DeleteNganh(_nganh.IdNganh);
            Navigation.NavigateTo("/nganhs");
        }
    }
}
