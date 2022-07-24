using AsmentCShap6.ViewModels.RequestFeatures;
using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using Assm6.Client.SinhVienInMonHocs;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class SinhVienInMonHoc
    {
        public List<SinhVienINMonHocViewModel> SVIMHList { get; set; } = new List<SinhVienINMonHocViewModel>();
        public MetaData MetaData { get; set; } = new MetaData();

        private Parameters _svmhParameters = new Parameters();

        [Inject]
        public ISinhvienInMonHocClient _isvmhClient { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetSVMHs();
        }

        private async Task SelectedPage(int page)
        {
            _svmhParameters.PageNumber = page;
            await GetSVMHs();
        }

        private async Task GetSVMHs()
        {
            var pagingResponse = await _isvmhClient.GetSinhVienInMonHocs(_svmhParameters);
            SVIMHList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _svmhParameters.PageNumber = 1;
            _svmhParameters.SearchTerm = searchTerm;
            await GetSVMHs();
        }
    }
}
