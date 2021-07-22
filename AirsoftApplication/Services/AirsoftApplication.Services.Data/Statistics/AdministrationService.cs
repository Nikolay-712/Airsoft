namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Linq;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Contacts;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Web.ViewModels.Administration.Dashboard;

    public class AdministrationService : IAdministrationServive
    {
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IDeletableEntityRepository<Event> events;
        private readonly IDeletableEntityRepository<Message> messges;

        public AdministrationService(
            IDeletableEntityRepository<ApplicationUser> users,
            IDeletableEntityRepository<Event> events,
            IDeletableEntityRepository<Message> messges)
        {
            this.users = users;
            this.events = events;
            this.messges = messges;
        }

        public AdministrationStatisticViewModel GetStatistic()
        {
            var statistic = new AdministrationStatisticViewModel
            {
                RegisteredUsers = this.users.All().ToList().Count(),
                OrganizedEvents = this.events.All().ToList().Count(),
                UnreadMessages = this.messges.All()
                    .Where(x => x.HasBeenRead == false)
                    .ToList().Count(),
            };

            return statistic;
        }
    }
}
