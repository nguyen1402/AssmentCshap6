using AsmentCShap6.ViewModels.Nganhs;
using AssmentCshap6.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.Monhocs.RepositoryExtensions
{
    public static class RepositoryMonHocExtensions
    {
        public static IQueryable<Monhoc> Search(this IQueryable<Monhoc> monhocs, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return monhocs;

            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

            return monhocs.Where(p => p.TenMonhoc.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
