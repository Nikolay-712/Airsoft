namespace AirsoftApplication.Services.Data.Events
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Administration.Events;
    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;

    public interface IEventService
    {
        IEnumerable<FieldViewModel> GetTeamFields();

        Task CreateEventAsync(InputEventViewModel input);

        Task CreateBattlefieldAsync(InputFieldViewModel input);

        EventViewModel UpcomingEvent();

        Task AddImagesAsync(InputEventImagesViewModel input);

        IEnumerable<EventViewModel> AllEvents();

        EventDeteilsViewModel EventDetails(string eventId);

        IEnumerable<ImageViewModel> EventImages(string eventId);
    }
}
