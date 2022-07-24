using AsmentCShap6.ViewModels.RequestFeatures;
using Assm6.Client.MonHocs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class MonHocs
    {
        public List<Monhoc> NganhList { get; set; } = new List<Monhoc>();
        public MetaData MetaData { get; set; } = new MetaData();

        private Parameters _monhocParameters = new Parameters();

        [Inject]
        public IMonhocClient _iMonhocClient { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetMonhocs();
        }

        private async Task SelectedPage(int page)
        {
            _monhocParameters.PageNumber = page;
            await GetMonhocs();
        }

        private async Task GetMonhocs()
        {
            var pagingResponse = await _iMonhocClient.GetMonhocs(_monhocParameters);
            NganhList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _monhocParameters.PageNumber = 1;
            _monhocParameters.SearchTerm = searchTerm;
            await GetMonhocs();
        }

    }
}
