namespace AirsoftApplication.Web.ViewModels.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AirsoftApplication.Common;
    using Microsoft.AspNetCore.Http;

    public class AllowedFileParmaetersAttribute : ValidationAttribute
    {
        private const int MaxFilesCont = 4;

        private const string NotSupportedFileExtension = "The file you are trying to learn is not supported. ( {0} )";
        private const string MaxFileSizeMessage = "The file you are trying to upload cannot be larger than {0} MB.";
        private const string MaxFilesContMessage = "You cannot add more than {0} fails";

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
                return new ValidationResult("Add photos!");
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
                    return new ValidationResult(string.Format(MaxFileSizeMessage, GlobalConstants.Files.MaxSize));
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
