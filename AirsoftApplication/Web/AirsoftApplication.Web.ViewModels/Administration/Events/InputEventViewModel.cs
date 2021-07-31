namespace AirsoftApplication.Web.ViewModels.Administration.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Common;
    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputEventViewModel
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
        [AllowedDateRange]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = GlobalConstants.DateTimeFormat.DateFormat, ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = GlobalConstants.DateTimeFormat.TimeFormat, ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Required]
        [AllowedFileParmaeters(new string[] { "jpg", "jpeg", "png" }, GlobalConstants.Files.MaxSize)]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        public string FieldId { get; set; }
    }
}
