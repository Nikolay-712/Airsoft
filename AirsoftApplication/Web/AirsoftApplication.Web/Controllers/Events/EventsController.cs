namespace AirsoftApplication.Web.Controllers.Events
{
    using System.Linq;

    using AirsoftApplication.Services.Data.Events;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private const int CommentsPerPage = 2;

        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult Index()
        {
            var gameEvent = this.eventService.UpcomingEvent();

            if (gameEvent == null)
            {
                return this.RedirectToAction("NoEvents");
            }

            return this.View(gameEvent);
        }

        public IActionResult EventDetails(string eventId, int page = 1)
        {
            var gameEvent = this.eventService.EventDetails(eventId);

            if (gameEvent == null)
            {
                return this.NotFound();
            }

            if (page <= 0)
            {
                return this.NotFound();
            }

            gameEvent.PageNumber = page;
            gameEvent.ItemsCount = gameEvent.CommentsCount;
            gameEvent.ItemsPerPage = CommentsPerPage;
            gameEvent.Comments = gameEvent.Comments.Skip((page - 1) * CommentsPerPage)
                      .Take(CommentsPerPage);

            if (page > gameEvent.PagesCount)
            {
                return this.NotFound();
            }

            return this.View(gameEvent);
        }

        public IActionResult NoEvents()
        {
            return this.View();
        }
    }
}
