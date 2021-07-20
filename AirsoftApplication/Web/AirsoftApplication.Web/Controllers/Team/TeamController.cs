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
            return this.View();
        }

        public IActionResult Events()
        {
            var events = this.teamService.AllEvents();
            return this.View(events);
        }

        public IActionResult Players()
        {
            var players = this.teamService.TeamList();
            return this.View(players);
        }

        public IActionResult Gallery(string eventId)
        {
            if (eventId == null)
            {
                return this.RedirectToAction("Events");
            }

            var images = this.teamService.EventImages(eventId);
            return this.View(images);
        }
    }
}
