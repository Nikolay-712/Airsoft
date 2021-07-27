namespace AirsoftApplication.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class InputSubCommentViewModel
    {
        [Required]
        public string CommentId { get; set; }

        [Required]
        public string EventId { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(10)]
        public string Content { get; set; }
    }
}
