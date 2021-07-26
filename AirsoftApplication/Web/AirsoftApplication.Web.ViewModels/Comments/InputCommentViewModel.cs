namespace AirsoftApplication.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class InputCommentViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(10)]
        public string Content { get; set; }
    }
}
