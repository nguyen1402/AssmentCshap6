using AsmentCShap6.ViewModels.SinhVienInMonHocs;
using Assm6.Client.SinhVienInMonHocs;
using AssmentCshap6.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace Assm6.Client.Pages
{
    public partial class UpdatesSinhVienInMonHoc
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

        private async Task Update()
        {
            if (idsv.Length == Guid.Empty.ToString().Length)
            {
                gg = new Guid(idsv);
            }
            var result = await _iSinhvienInMonHocClient.UpdateSinhVienInMonHoc(gg, Convert.ToInt32(idmh), _svmh);

            if (!result.IsSuccessed)
            {
                Error = result.Message;
                ShowAuthError = true;
            }
            else
            {
                Navigation.NavigateTo("/sinhvieninmonhocs");
            }
        }
    }
}
