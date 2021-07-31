namespace AirsoftApplication.Services.Data.Team
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;

    public interface ITeamService
    {
        IEnumerable<UserViewModel> TeamList();

        IEnumerable<EventViewModel> AllEvents();

        IEnumerable<ImageViewModel> EventImages(string eventId);

        IEnumerable<MostRatedEventViewModel> MostRatedEvents();
    }
}
