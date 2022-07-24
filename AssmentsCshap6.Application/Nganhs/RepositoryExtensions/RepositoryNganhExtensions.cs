using AsmentCShap6.ViewModels.Nganhs;
using AssmentCshap6.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssmentsCshap6.Application.Nganhs.RepositoryExtensions
{
    public static class RepositoryMonHocExtensions
    {
        public static IQueryable<Nganh> Search(this IQueryable<Nganh> products, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return products;

            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

            return products.Where(p => p.TenNganh.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
