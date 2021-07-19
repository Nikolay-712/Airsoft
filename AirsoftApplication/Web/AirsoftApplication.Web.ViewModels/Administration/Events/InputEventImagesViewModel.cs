namespace AirsoftApplication.Web.ViewModels.Administration.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputEventImagesViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [AllowedFileParmaeters(new string[] { "jpg", "png", "jpeg" }, 5)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
