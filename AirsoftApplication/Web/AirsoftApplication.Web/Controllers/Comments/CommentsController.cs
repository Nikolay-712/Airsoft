namespace AirsoftApplication.Web.Controllers.Comments
{
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Comments;
    using AirsoftApplication.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        public IActionResult Index(string eventId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InputCommentViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            string userId = null;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (user != null)
            {
                userId = user.Id;
            }

            if (input.EventId == null)
            {
                return this.RedirectToAction("Events", "Team");
            }

            await this.commentService.AddCommentAsync(userId, input);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = input.EventId });
        }

        public IActionResult SubComment(string commentId, string eventId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SubComment(InputSubCommentViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            string userId = null;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (user != null)
            {
                userId = user.Id;
            }

            if (input.EventId == null)
            {
                return this.RedirectToAction("Events", "Team");
            }
            await this.commentService.AddSubCommentAsync(userId, input);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = input.EventId });
        }
    }
}
