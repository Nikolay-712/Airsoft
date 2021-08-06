namespace AirsoftApplication.Web.Areas.Administration.Controllers.Events
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Events;
    using AirsoftApplication.Web.ViewModels.Administration.Events;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : AdministrationController
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult CreateEvent()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(InputEventViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.eventService.CreateEventAsync(input);

            return this.RedirectToAction("Index", "Events", new { Area = string.Empty });
        }

        public IActionResult CreateField()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateField(InputFieldViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.eventService.CreateBattlefieldAsync(input);

            return this.RedirectToAction("CreateEvent");
        }

        public IActionResult AddImages(string eventId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(InputEventImagesViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.eventService.AddImagesAsync(input);

            return this.RedirectToAction("Gallery", "Team", new { eventId = input.EventId, Area = string.Empty });
        }
    }
}
