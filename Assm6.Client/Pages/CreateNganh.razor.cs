using AsmentCShap6.ViewModels.Nganhs;
using Assm6.Client.Nganhs;
using Assm6.Client.Shared;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class CreateNganh
    {
        private CreatNganh _nganh = new CreatNganh();
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public INganhClient _iNganhClient { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        private async Task Create()
        {
            ShowAuthError = false;
            var result = await _iNganhClient.CreateNganh(_nganh);
            
            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
                Navigation.NavigateTo("/createNganh");
            }
            else
            {
                Navigation.NavigateTo("/nganhs");
            }
        }
    }
}
