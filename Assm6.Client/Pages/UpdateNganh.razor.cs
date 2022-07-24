using AsmentCShap6.ViewModels.Nganhs;
using Assm6.Client.Nganhs;
using Assm6.Client.Shared;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class UpdateNganh
    {
        private Nganh _nganh;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        INganhClient _NganhClient { get; set; }
        [Parameter]
        public string Id { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        protected async override Task OnInitializedAsync()
        {
            _nganh = await _NganhClient.GetNganh(Convert.ToInt32(Id));
        }

        private async Task Update()
        {
          var result = await _NganhClient.UpdateNganh(_nganh);
           
            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
            }
            else
            {
                Navigation.NavigateTo("/nganhs");
            }
        }
    }
}
