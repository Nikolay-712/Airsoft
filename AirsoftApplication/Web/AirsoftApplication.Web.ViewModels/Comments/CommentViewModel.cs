namespace AirsoftApplication.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Vote;

    public class CommentViewModel
    {
        public string Id { get; set; }

        public string Date { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string PlayerName { get; set; }

        public string ProfileImageUrl { get; set; }

        public VoteViewModel Vote { get; set; }

        public IEnumerable<CommentViewModel> SubComments { get; set; }
    }
}
