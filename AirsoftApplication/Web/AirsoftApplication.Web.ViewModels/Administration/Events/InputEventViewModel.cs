namespace AirsoftApplication.Web.ViewModels.Administration.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class InputEventViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        [AllowedDateRange]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "HH:mm", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Required]
        [AllowedFileParmaeters(new string[] { "jpg", "jpeg", "png" }, 5)]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        public string FieldId { get; set; }
    }
}
