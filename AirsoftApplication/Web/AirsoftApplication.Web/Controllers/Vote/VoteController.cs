namespace AirsoftApplication.Web.Controllers.Vote
{
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class VoteController : Controller
    {
        private readonly IVoteService voteService;
        private readonly UserManager<ApplicationUser> userManager;

        public VoteController(
            IVoteService voteService,
            UserManager<ApplicationUser> userManager)
        {
            this.voteService = voteService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> PositiveVote(string guidingId, string eventId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var isUpVote = true;
            await this.voteService.VoteAsync(guidingId, user.Id, isUpVote);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = eventId });
        }

        public async Task<IActionResult> NegativeVote(string guidingId, string eventId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var isUpVote = false;
            await this.voteService.VoteAsync(guidingId, user.Id, isUpVote);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = eventId });
        }
    }
}
