namespace AirsoftApplication.Services.Data.Statistics
{
    using System;
    using System.Linq;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Contacts;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Team;
    using AirsoftApplication.Web.ViewModels.Administration.Dashboard;
    using Microsoft.Extensions.Caching.Memory;

    public class AdministrationService : IAdministrationServive
    {
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IDeletableEntityRepository<Event> events;
        private readonly IDeletableEntityRepository<Message> messges;
        private readonly ITeamService teamService;
        private readonly IMemoryCache memoryCache;

        public AdministrationService(
            IDeletableEntityRepository<ApplicationUser> users,
            IDeletableEntityRepository<Event> events,
            IDeletableEntityRepository<Message> messges,
            ITeamService teamService,
            IMemoryCache memoryCache)
        {
            this.users = users;
            this.events = events;
            this.messges = messges;
            this.teamService = teamService;
            this.memoryCache = memoryCache;
        }

        public AdministrationStatisticViewModel GetStatistic()
        {
            var statistic = this.memoryCache
                .Get<AdministrationStatisticViewModel>(GlobalConstants.AdministrationCacheKey);

            if (statistic == null)
            {
                statistic = new AdministrationStatisticViewModel
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

                var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.memoryCache.Set(GlobalConstants.AdministrationCacheKey, statistic, cacheOptions);
            }

            return statistic;
        }
    }
}
