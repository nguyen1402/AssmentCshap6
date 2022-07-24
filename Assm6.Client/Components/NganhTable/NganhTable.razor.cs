using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Assm6.Client.Components.NganhTable
{
    public partial class NganhTable
    {
        [Parameter]
        public List<Nganh> Nganhs { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        private void RedirectToUpdate(int id)
        {
            
            var url = Path.Combine("/updateNganh/",id.ToString());
            NavigationManager.NavigateTo(url);
        }

        private async Task RedirectToDelete(int id)
        {
            var url = Path.Combine("/deleteNganh/", id.ToString());
            NavigationManager.NavigateTo(url);
        }
    }
}
