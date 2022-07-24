using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using Assm6.Client.SinhVienInMonHocs;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class DeletesSinhVienInMonHoc
    {
        private SinhVienINMonHocViewModel _svmh;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        ISinhvienInMonHocClient _iSinhvienInMonHocClient { get; set; }
        [Parameter]
        public string idsv { get; set; }

        [Parameter]
        public string idmh { get; set; }

        [Parameter]
        public Guid gg { get; set; }
        public bool ShowAuthError { get; set; }
        [Parameter]
        public string Error { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (idsv.Length == Guid.Empty.ToString().Length)
            {
                gg = new Guid(idsv);
            }
            _svmh = await _iSinhvienInMonHocClient.GetSinhVienInMonHoc(gg, Convert.ToInt32(idmh));
        }

        private async Task Delete()
        {
            if (idsv.Length == Guid.Empty.ToString().Length)
            {
                gg = new Guid(idsv);
            }
            var result = await _iSinhvienInMonHocClient.DeleteSinhVienInMonHoc(gg, Convert.ToInt32(idmh));

            if (!result)
            {
                Error = "Xóa thất bại!";
                ShowAuthError = true;
            }
            else
            {
                Navigation.NavigateTo("/sinhvieninmonhocs");
            }
        }
    }
}
