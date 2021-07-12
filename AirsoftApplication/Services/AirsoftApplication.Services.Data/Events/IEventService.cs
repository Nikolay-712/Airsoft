namespace AirsoftApplication.Services.Data.Events
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Administration.Events;
    using AirsoftApplication.Web.ViewModels.Events;

    public interface IEventService
    {
        IEnumerable<FieldViewModel> GetTeamFields();

        Task CreateEventAsync(InputEventViewModel input);

        Task CreateBattlefieldAsync(InputFieldViewModel input);

        EventViewModel UpcomingEvent();
    }
}
