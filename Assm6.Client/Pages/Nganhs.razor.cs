using AsmentCShap6.ViewModels.RequestFeatures;
using Assm6.Client.Nganhs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class Nganhs
    {
        public List<Nganh> NganhList { get; set; } = new List<Nganh>();
        public MetaData MetaData { get; set; } = new MetaData();

        private Parameters _nganhParameters = new Parameters();

        [Inject]
        public INganhClient _iNganhClient { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetNganhs();
        }

        private async Task SelectedPage(int page)
        {
            _nganhParameters.PageNumber = page;
            await GetNganhs();
        }

        private async Task GetNganhs()
        {
            var pagingResponse = await _iNganhClient.GetNganhs(_nganhParameters);
            NganhList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _nganhParameters.PageNumber = 1;
            _nganhParameters.SearchTerm = searchTerm;
            await GetNganhs();
        }
    }
}
