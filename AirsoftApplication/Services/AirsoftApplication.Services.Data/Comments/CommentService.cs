namespace AirsoftApplication.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Comments;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Services.Mapping;
    using AirsoftApplication.Web.ViewModels.Comments;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;
        private readonly IDeletableEntityRepository<SubComment> subCommentRepository;
        private readonly IImageService imageService;

        public CommentService(
            IDeletableEntityRepository<Comment> commentRepository,
            IDeletableEntityRepository<SubComment> subCommentRepository,
            IImageService imageService)
        {
            this.commentRepository = commentRepository;
            this.subCommentRepository = subCommentRepository;
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

        public async Task AddSubCommentAsync(string userId, InputSubCommentViewModel input)
        {
            var subComment = new SubComment
            {
                Content = input.Content,
                CommentId = input.CommentId,
                UserId = userId,
            };

            await this.subCommentRepository.AddAsync(subComment);
            await this.subCommentRepository.SaveChangesAsync();
        }

        public IEnumerable<CommentViewModel> AllCommentsByEvent(string eventId)
        {
            var comments = this.commentRepository.All()
                .Where(x => x.EventId == eventId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Date = x.CreatedOn.ToString("dd.MM.yyyy"),
                    Content = x.Content,
                    UserId = x.UserId,
                    PlayerName = x.User.PlayerName,
                    ProfileImageUrl = this.imageService.GetProfileImageUrl(x.UserId),
                    SubComments = x.SubComments
                        .Where(sc => sc.CommentId == x.Id)
                        .OrderByDescending(sc => sc.CreatedOn)
                        .Select(sc => new CommentViewModel
                        {
                            Id = sc.Id,
                            Date = sc.CreatedOn.ToString("dd.MM.yyyy"),
                            Content = sc.Content,
                            UserId = sc.UserId,
                            PlayerName = sc.User.PlayerName,
                            ProfileImageUrl = this.imageService.GetProfileImageUrl(sc.UserId),
                        }).ToList(),
                }).ToList();

            return comments;
        }

        public CommentViewModel CommentById(string commentId, string eventId)
        {
            var comment = this.AllCommentsByEvent(eventId).FirstOrDefault(x => x.Id == commentId);
            return comment;
        }
    }
}
