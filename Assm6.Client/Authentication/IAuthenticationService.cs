using AssmentCshap6.Data.Common;
using AssmentCshap6.Data.ViewModels;

namespace Assm6.Client.Authentication
{
    public interface IAuthenticationService
    {
        Task<ApiResult<bool>> RegisterUser(Registerequest userForRegistration);
        Task<ApiResult<string>> Login(Loginrequest userForAuthentication);
        Task Logout();
    }
}
