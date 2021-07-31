namespace AirsoftApplication.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Common;

    public class InputMessageViewModel
    {
        [Required]
        [MaxLength(GlobalConstants.NameMaxLenght)]
        [MinLength(GlobalConstants.NameMinLenght)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.NameMaxLenght)]
        [MinLength(GlobalConstants.NameMinLenght)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLenght)]
        [MinLength(GlobalConstants.MessageContentMinLenght)]
        public string Content { get; set; }
    }
}
