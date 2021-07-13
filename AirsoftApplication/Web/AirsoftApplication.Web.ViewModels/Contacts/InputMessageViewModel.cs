namespace AirsoftApplication.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class InputMessageViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(20)]
        public string Content { get; set; }
    }
}
