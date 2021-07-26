namespace AirsoftApplication.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Comments;

    public interface ICommentService
    {
        Task AddCommentAsync(string userId, InputCommentViewModel input);

        IEnumerable<CommentViewModel> AllComments(string eventId);
    }
}
