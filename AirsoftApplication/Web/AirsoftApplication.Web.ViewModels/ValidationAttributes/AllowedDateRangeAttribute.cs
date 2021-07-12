namespace AirsoftApplication.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AllowedDateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime? currentDate = value as DateTime?;

            if (currentDate < DateTime.UtcNow)
            {
                return new ValidationResult("Invalid date");
            }

            return ValidationResult.Success;
        }
    }
}
