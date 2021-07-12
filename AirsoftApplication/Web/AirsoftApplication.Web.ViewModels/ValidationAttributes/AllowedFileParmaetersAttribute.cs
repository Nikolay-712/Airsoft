namespace AirsoftApplication.Web.ViewModels.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class AllowedFileParmaetersAttribute : ValidationAttribute
    {
        private const int MaxFilesCont = 4;

        private const string NotSupportedFileExtension = "Фаила който се опитвате да качите не се подържа. ( {0} )";
        private const string MaxFileSizeMessage = "Фаила който се опитвате да качите не може да бъде по голям от {0}";
        private const string MaxFilesContMessage = "Не може да добавите повече от {0} фаила";

        private readonly string[] fileExtensions;
        private readonly int maxFileSize;

        public AllowedFileParmaetersAttribute(string[] fileExtensions, int maxFileSize)
        {
            this.fileExtensions = fileExtensions;
            this.maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as IEnumerable<IFormFile>;

            if (files == null)
            {
                return new ValidationResult("Добавете снимки!");
            }


            if (files.Count() > MaxFilesCont)
            {
                return new ValidationResult(string.Format(MaxFilesContMessage, MaxFilesCont));
            }

            foreach (var file in files)
            {
                var contentTyep = file.ContentType.Split("/", System.StringSplitOptions.RemoveEmptyEntries);

                var maxSize = this.maxFileSize * 1024 * 1024;

                if (file.Length > maxSize)
                {
                    return new ValidationResult(string.Format(MaxFileSizeMessage, "5 MB."));
                }

                if (!this.fileExtensions.Contains(contentTyep[1]))
                {
                    return new ValidationResult(string.Format(NotSupportedFileExtension, contentTyep[1]));
                }
            }

            return ValidationResult.Success;
        }
    }
}
