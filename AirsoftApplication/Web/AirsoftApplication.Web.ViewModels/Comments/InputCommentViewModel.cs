namespace AirsoftApplication.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Common;

    public class InputCommentViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ContentTextMaxLenght)]
        [MinLength(GlobalConstants.ContentTextMinLenght)]
        public string Content { get; set; }
    }
}
