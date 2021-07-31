namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Linq;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Contacts;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Team;
    using AirsoftApplication.Web.ViewModels.Administration.Dashboard;

    public class AdministrationService : IAdministrationServive
    {
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IDeletableEntityRepository<Event> events;
        private readonly IDeletableEntityRepository<Message> messges;
        private readonly ITeamService teamService;

        public AdministrationService(
            IDeletableEntityRepository<ApplicationUser> users,
            IDeletableEntityRepository<Event> events,
            IDeletableEntityRepository<Message> messges,
            ITeamService teamService)
        {
            this.users = users;
            this.events = events;
            this.messges = messges;
            this.teamService = teamService;
        }

        public AdministrationStatisticViewModel GetStatistic()
        {
            var statistic = new AdministrationStatisticViewModel
            {
                RegisteredUsers = this.users.All().ToList().Count(),
                OrganizedEvents = this.events.All().ToList().Count(),
                UsersInTeamRole = this.users.All()
                    .Where(x => x.Roles.Count > 0)
                    .Count(),
                UnreadMessages = this.messges.All()
                    .Where(x => x.HasBeenRead == false)
                    .ToList().Count(),
                Events = this.teamService.MostRatedEvents()
                    .OrderByDescending(x => x.Vote.PositiveVotes)
                    .Take(3),
            };

            return statistic;
        }
    }
}
