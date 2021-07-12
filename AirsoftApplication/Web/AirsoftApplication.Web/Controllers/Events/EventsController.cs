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

            return this.View(gameEvent);
        }
    }
}
