using Assm6.Client.MonHocs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class UpdateMonHoc
    {
        private Monhoc _monhoc;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        IMonhocClient _iMonhocClient { get; set; }
        
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _monhoc = await _iMonhocClient.GetMonhoc(Convert.ToInt32(Id));
        }

        private async Task Update()
        {
          var result =  await _iMonhocClient.UpdateMonhoc(_monhoc);
            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
            }
            else
            {
                Navigation.NavigateTo("/monhocs");
            }
            
        }
        private void AssignImageUrl(string imgUrl) => _monhoc.ImageUrl = imgUrl;
    }
}
