namespace AirsoftApplication.Web.ViewModels.Administration.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class MessageViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public bool HasBeenRead { get; set; }

        public string CreatedOn { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string MessageSubject { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(10)]
        public string MessageContent { get; set; }
    }
}
