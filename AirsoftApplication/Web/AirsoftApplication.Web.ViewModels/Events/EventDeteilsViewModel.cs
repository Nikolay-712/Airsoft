namespace AirsoftApplication.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.Linq;

    using AirsoftApplication.Web.ViewModels.Comments;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Vote;

    public class EventDeteilsViewModel : PagingViewModel
    {
        public string Id { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public ImageViewModel CoverImage => this.Images.OrderBy(x => x.CreatedOn).FirstOrDefault();

        public string Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CommentsCount => this.Comments.Count();

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public VoteViewModel Vote { get; set; }
    }
}
