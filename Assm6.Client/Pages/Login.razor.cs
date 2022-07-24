using Assm6.Client.Authentication;
using AssmentCshap6.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class Login
    {
        private Loginrequest _userForAuthentication = new Loginrequest();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.Login(_userForAuthentication);
            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
