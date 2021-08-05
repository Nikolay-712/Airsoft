namespace AirsoftApplication.Web.Controllers.Events
{
    using AirsoftApplication.Services.Data.Events;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
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

        public IActionResult EventDetails(string eventId)
        {
            var gameEvent = this.eventService.EventDetails(eventId);

            if (gameEvent == null)
            {
                return this.BadRequest();
            }

            return this.View(gameEvent);
        }

        public IActionResult NoEvents()
        {
            return this.View();
        }
    }
}
