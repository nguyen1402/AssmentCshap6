using AsmentCShap6.ViewModels.Schools;
using Assm6.Client.MonHocs;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class CreateMonHoc
    {
        private CreatMonHoc _monhoc = new CreatMonHoc();
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IMonhocClient _iMonhocClient { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        private async Task Create()
        {
          var result =   await _iMonhocClient.CreateMonhoc(_monhoc);
            
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
