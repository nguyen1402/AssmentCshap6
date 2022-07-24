using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using Assm6.Client.MonHocs;
using Assm6.Client.SinhVienInMonHocs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class CreatsSinhVienInMonHoc
    {
        private CreatSinhVienInMonHoc _sinhvieninmh = new CreatSinhVienInMonHoc();
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISinhvienInMonHocClient _iSinhvienInMonHocClient { get; set; }
        [Inject]
        public IMonhocClient _iMonhocClient { get; set; }

        private IEnumerable<Monhoc> monhocList;

        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        protected override async Task OnInitializedAsync()
        {
            monhocList = await _iMonhocClient.GetlsMonhocs();
        }
        private async Task Create()
        {
            ShowAuthError = false;
            var result = await _iSinhvienInMonHocClient.CreateSinhVienInMonHoc(_sinhvieninmh);
            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
                Navigation.NavigateTo("/createSinhVienInMonHoc");
            }
            else
            {
                Navigation.NavigateTo("/sinhvieninmonhocs");
            }
        }
    }
}
