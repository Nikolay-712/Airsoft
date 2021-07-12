namespace AirsoftApplication.Web.ViewModels.Administration.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputFieldViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string LocationUrl { get; set; }

        [Required]
        [AllowedFileParmaeters(new string[] { "jpg", "jpeg", "png" }, 5)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
