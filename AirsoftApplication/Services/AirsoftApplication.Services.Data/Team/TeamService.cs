namespace AirsoftApplication.Services.Data.Team
{
    using System.Collections.Generic;
    using System.Linq;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Events;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Services.Data.Statistics;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Services.Data.Votes;
    using AirsoftApplication.Web.ViewModels.Administration.Users;
    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;

    public class TeamService : ITeamService
    {
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IUserService userService;
        private readonly IEventService eventService;
        private readonly IVoteService voteService;
        private readonly IImageService imageService;
        private readonly IStatisticService statisticService;

        public TeamService(
            IDeletableEntityRepository<Event> eventRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IUserService userService,
            IEventService eventService,
            IVoteService voteService,
            IImageService imageService,
            IStatisticService statisticService)
        {
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
            this.userService = userService;
            this.eventService = eventService;
            this.voteService = voteService;
            this.imageService = imageService;
            this.statisticService = statisticService;
        }

        public IEnumerable<UserViewModel> TeamList()
        {
            var players = this.userService
                .GetAllUsers()
                .Where(x => x.AllUserRoles
                .Contains(GlobalConstants.ApplicationRole.SoldierRoleName) ||
                x.AllUserRoles.Contains(GlobalConstants.ApplicationRole.CaptainRoleName))
                .ToList();

            return players;
        }

        public IEnumerable<UserStatisticViewModel> UserStatistics()
        {
            var users = this.userRepository.All()
                 .Select(x => new UserStatisticViewModel
                 {
                     UserId = x.Id,
                     ProfileImageUrl = this.imageService.GetProfileImageUrl(x.Id),
                     Username = x.PlayerName,
                     StatisticInfos = this.statisticService.GetUserStatistic(x.Id),
                 })
                 .Where(x => x.Username != "Admin").ToList();

            return users;
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
