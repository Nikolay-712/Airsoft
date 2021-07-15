namespace AirsoftApplication.Web.ViewModels.Images
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputImageViewModel
    {
        [AllowedFileParmaeters(new string[] { "jpg", "png", "jpeg" }, 5)]
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
