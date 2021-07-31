namespace AirsoftApplication.Services.Data.Team
{
    using System.Collections.Generic;
    using System.Linq;
    using AirsoftApplication.Common;
    using AirsoftApplication.Services.Data.Events;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;

    public class TeamService : ITeamService
    {
        private readonly IUserService userService;
        private readonly IEventService eventService;

        public TeamService(IUserService userService, IEventService eventService)
        {
            this.userService = userService;
            this.eventService = eventService;
        }

        public IEnumerable<UserViewModel> TeamList()
        {
            var players = this.userService
                .GetAllUsers()
                .Where(x => x.AllUserRoles.Contains(GlobalConstants.ApplicationRole.SoldierRoleName)).ToList();

            return players;
        }

        public IEnumerable<EventViewModel> AllEvents()
        {
            var events = this.eventService.AllEvents();
            return events;
        }

        public IEnumerable<ImageViewModel> EventImages(string eventId)
        {
            var images = this.eventService.EventImages(eventId);
            return images;
        }
    }
}
