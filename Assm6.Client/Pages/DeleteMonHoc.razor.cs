using Assm6.Client.MonHocs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class DeleteMonHoc
    {
        private Monhoc _monhoc;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        IMonhocClient _iMonhocClient { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _monhoc = await _iMonhocClient.GetMonhoc(Convert.ToInt32(Id));
        }

        private async Task Delete()
        {
            await _iMonhocClient.DeleteMonhoc(_monhoc.IdMonhoc);
            Navigation.NavigateTo("/monhocs");
        }
    }
}
