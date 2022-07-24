using Assm6.Client.Authentication;
using AssmentCshap6.Data.Enum;
using AssmentCshap6.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class Register
    {
        private Registerequest _userRg = new Registerequest();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool ShowAuthError { get; set; }
        public string Error { get; set; }
        public int nam = (int)Sex.male;
        public int nu = (int)Sex.female;
        public string Succes { get; set; }
        public async Task Registerss()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.RegisterUser(_userRg);
            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
                
            }
            else
            {
                Succes = "Đang kí thành công";
                //NavigationManager.NavigateTo("/");
            }
        }
    }
}
