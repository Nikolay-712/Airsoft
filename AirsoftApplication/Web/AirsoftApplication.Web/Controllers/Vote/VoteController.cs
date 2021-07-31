namespace AirsoftApplication.Web.Controllers.Vote
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Votes;
    using AirsoftApplication.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class VoteController : Controller
    {
        private readonly IVoteService voteService;

        public VoteController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        public async Task<IActionResult> PositiveVote(string guidingId, string eventId)
        {
            var isUpVote = true;
            await this.voteService.VoteAsync(guidingId, ClaimsPrincipalExtensions.Id(this.User), isUpVote);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = eventId });
        }

        public async Task<IActionResult> NegativeVote(string guidingId, string eventId)
        {
            var isUpVote = false;
            await this.voteService.VoteAsync(guidingId, ClaimsPrincipalExtensions.Id(this.User), isUpVote);

            return this.RedirectToAction("EventDetails", "Events", new { eventId = eventId });
        }
    }
}
