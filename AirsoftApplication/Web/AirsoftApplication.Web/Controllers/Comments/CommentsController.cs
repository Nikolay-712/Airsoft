namespace AirsoftApplication.Web.Controllers.Comments
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Comments;
    using AirsoftApplication.Web.Infrastructure;
    using AirsoftApplication.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Index(string eventId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InputCommentViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (input.EventId == null)
            {
                return this.RedirectToAction("Events", "Team");
            }

            await this.commentService.AddCommentAsync(ClaimsPrincipalExtensions.Id(this.User), input);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = input.EventId });
        }

        public IActionResult SubComment(string commentId, string eventId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SubComment(InputSubCommentViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (input.EventId == null)
            {
                return this.RedirectToAction("Events", "Team");
            }

            await this.commentService.AddSubCommentAsync(ClaimsPrincipalExtensions.Id(this.User), input);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = input.EventId });
        }
    }
}
