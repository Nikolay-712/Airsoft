namespace AirsoftApplication.Web.ViewModels.Administration.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Common;
    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputFieldViewModel
    {
        [Required]
        [MaxLength(GlobalConstants.NameMaxLenght)]
        [MinLength(GlobalConstants.NameMinLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ContentTextMaxLenght)]
        [MinLength(GlobalConstants.ContentTextMinLenght)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string LocationUrl { get; set; }

        [Required]
        [AllowedFileParmaeters(new string[] { "jpg", "jpeg", "png" }, GlobalConstants.Files.MaxSize)]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
