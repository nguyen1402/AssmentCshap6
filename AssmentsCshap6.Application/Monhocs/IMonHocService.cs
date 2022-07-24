using AsmentCShap6.ViewModels.Common;
using AsmentCShap6.ViewModels.MonHocs;
using AsmentCShap6.ViewModels.Paging;
using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.Schools;
using AssmentCshap6.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.Monhocs
{
    public interface IMonHocService
    {
        Task<PagedList<Monhoc>> GetMonHocs(Parameters monhocParameters);
        Task<ApiResult<bool>> CreateMonHoc(CreatMonHoc monhoc);
        Task<Monhoc> GetMonHoc(int id);
        Task<ApiResult<bool>> UpdateMonHoc(UpdateMonHoc monhoc, Monhoc dbmonhoc);
        Task DeleteMonHoc(Monhoc monhocdelete);
        Task<List<Monhoc>> GetlsMonhocs();
    }
}
