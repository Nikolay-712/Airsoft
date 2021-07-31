namespace AirsoftApplication.Web.ViewModels.Administration.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Common;
    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputEventImagesViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [AllowedFileParmaeters(new string[] { "jpg", "png", "jpeg" }, GlobalConstants.Files.MaxSize)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
