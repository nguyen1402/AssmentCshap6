using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Components.SinhVienInMonHocTable
{
    public partial class SinhVienInMonHocTable
    {
        [Parameter]
        public List<SinhVienINMonHocViewModel> SinhVienInMonHocs { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private void RedirectToUpdate(Guid idsv,int idmh)
        {

            var url = Path.Combine("/updateSinhVienInMonHoc/", idsv.ToString(), idmh.ToString());
            NavigationManager.NavigateTo(url);
        }

        private async Task RedirectToDelete(Guid idsv, int idmh)
        {
            var url = Path.Combine("/deleteSinhVienInMonHoc/", idsv.ToString(), idmh.ToString());
            NavigationManager.NavigateTo(url);
        }
    }
}
