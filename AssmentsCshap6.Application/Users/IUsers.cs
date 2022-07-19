using AssmentCshap6.Data.Common;
using AssmentCshap6.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.Users
{
    public interface IUsers
    {
        Task<ApiResult<string>> Authencate(Loginrequest request);
        Task<ApiResult<bool>> Register(Registerequest request);
    }
}
