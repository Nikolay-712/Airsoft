namespace AirsoftApplication.Services.Data.Team
{
    using System.Collections.Generic;
    using System.Linq;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Services.Data.Events;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Services.Data.Votes;
    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;

    public class TeamService : ITeamService
    {
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IUserService userService;
        private readonly IEventService eventService;
        private readonly IVoteService voteService;

        public TeamService(
            IDeletableEntityRepository<Event> eventRepository,
            IUserService userService,
            IEventService eventService,
            IVoteService voteService)
        {
            this.eventRepository = eventRepository;
            this.userService = userService;
            this.eventService = eventService;
            this.voteService = voteService;
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

        public IEnumerable<MostRatedEventViewModel> MostRatedEvents()
        {
            var events = this.eventRepository.All()
                .Select(x => new MostRatedEventViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Date = x.Date.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                    Location = x.Field.Location,
                    Vote = this.voteService.GetVotes(x.Id),
                })
                .ToList();

            return events;
        }
    }
}
