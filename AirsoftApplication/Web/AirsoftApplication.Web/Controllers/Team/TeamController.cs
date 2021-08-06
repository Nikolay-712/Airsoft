namespace AirsoftApplication.Web.Controllers.Team
{
    using AirsoftApplication.Services.Data.Team;
    using Microsoft.AspNetCore.Mvc;

    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public IActionResult Index()
        {
            var players = this.teamService.TeamList();
            return this.View(players);
        }

        public IActionResult Events()
        {
            var events = this.teamService.AllEvents();
            return this.View(events);
        }

        public IActionResult Gallery(string eventId)
        {
            if (eventId == null)
            {
                return this.RedirectToAction("Events");
            }

            var images = this.teamService.EventImages(eventId);
            if (images == null)
            {
                return this.BadRequest();
            }

            return this.View(images);
        }
    }
}
