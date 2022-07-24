using AsmentCShap6.ViewModels.SinhVienInMonHocs;

namespace AssmentsCshap6.Application.SinhVienInMonHocs.RepositoryExtensions
{
    public static class RepositorySinhvienInMonHocServiceExtensions
    {
        public static IQueryable<SinhVienINMonHocViewModel> Search(this IQueryable<SinhVienINMonHocViewModel> products, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return products;

            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

            return products.Where(p => p.Email.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
