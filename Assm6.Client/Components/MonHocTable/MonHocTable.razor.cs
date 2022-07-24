using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Components.MonHocTable
{
    public partial class MonHocTable
    {
        [Parameter]
        public List<Monhoc> Monhocs { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private void RedirectToUpdate(int id)
        {

            var url = Path.Combine("/updateMonhoc/", id.ToString());
            NavigationManager.NavigateTo(url);
        }

        private async Task RedirectToDelete(int id)
        {
            var url = Path.Combine("/deleteMonhoc/", id.ToString());
            NavigationManager.NavigateTo(url);
        }
    }
}
