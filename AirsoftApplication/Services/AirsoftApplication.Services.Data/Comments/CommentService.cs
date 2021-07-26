namespace AirsoftApplication.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Comments;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Web.ViewModels.Comments;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;
        private readonly IImageService imageService;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository, IImageService imageService)
        {
            this.commentRepository = commentRepository;
            this.imageService = imageService;
        }

        public async Task AddCommentAsync(string userId, InputCommentViewModel input)
        {
            var comment = new Comment
            {
                EventId = input.EventId,
                Content = input.Content,
                UserId = userId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }

        public IEnumerable<CommentViewModel> AllComments(string eventId)
        {
            var comments = this.commentRepository.All()
                .Where(x => x.EventId == eventId)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Date = x.CreatedOn.ToString("dd.MM.yyyy"),
                    Content = x.Content,
                    UserId = x.UserId,
                    PlayerName = x.User.PlayerName,
                    Images = this.imageService.GetAllImages(x.UserId),
                }).ToList();

            return comments;
        }
    }
}
