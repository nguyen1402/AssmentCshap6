using Assm6.Client.Nganhs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace Assm6.Client.Shared
{
    public partial class ImageUpload
    {
        [Parameter]
        public string ImgUrl { get; set; }
        [Parameter]
        public EventCallback<string> OnChange { get; set; }
        [Inject]
        public INganhClient _iNganhClient { get; set; }

        private async Task HandleSelected(InputFileChangeEventArgs e)
        {
            var imageFiles = e.GetMultipleFiles();
            foreach (var imageFile in imageFiles)
            {
                if (imageFile != null)
                {
                    var resizedFile = await imageFile.RequestImageFileAsync("image/png", 300, 500);

                    using (var ms = resizedFile.OpenReadStream(resizedFile.Size))
                    {
                        var content = new MultipartFormDataContent();
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                        content.Add(new StreamContent(ms, Convert.ToInt32(resizedFile.Size)), "image", imageFile.Name);
                        ImgUrl = await _iNganhClient.UploadProductImage(content);
                        await OnChange.InvokeAsync(ImgUrl);
                    }
                }
            }
        }
    }
}
