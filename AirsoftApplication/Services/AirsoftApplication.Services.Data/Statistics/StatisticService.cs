namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Statistics;
    using AirsoftApplication.Services.Data.Events;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Web.ViewModels.Administration.Statistics;

    public class StatisticService : IStatisticService
    {
        private readonly IDeletableEntityRepository<Statistic> statisticyRepository;
        private readonly IDeletableEntityRepository<StatisticInfo> infoRepository;
        private readonly IUserService userService;
        private readonly IEventService eventService;

        public StatisticService(
            IDeletableEntityRepository<Statistic> statisticyRepository,
            IDeletableEntityRepository<StatisticInfo> infoRepository,
            IUserService userService,
            IEventService eventService)
        {
            this.statisticyRepository = statisticyRepository;
            this.infoRepository = infoRepository;
            this.userService = userService;
            this.eventService = eventService;
        }

        public StatisticViewModel GetUserInfo(string userId)
        {
            var user = this.userService.GetUserById(userId);

            var statistic = new StatisticViewModel
            {
                User = user,
            };

            return statistic;
        }

        public async Task CreateStatisticAsync(StatisticViewModel model)
        {
            var gameevent = this.eventService.UpcomingEvent();
            var statisticId = string.Empty;

            var existingStatistic = this.statisticyRepository.All()
                .Where(x => x.EventId == gameevent.Id && x.UserId == model.UserId)
                .FirstOrDefault();

            if (existingStatistic == null)
            {
                var statistic = new Statistic
                {
                    UserId = model.UserId,
                    EventId = gameevent.Id,
                };

                statisticId = statistic.Id;

                await this.statisticyRepository.AddAsync(statistic);
                await this.statisticyRepository.SaveChangesAsync();
            }
            else
            {
                statisticId = existingStatistic.Id;
            }

            var statisticInfo = new StatisticInfo
            {
                StatisticId = statisticId,
                GunId = model.GunId,
                GunEnergy = model.GunEnergy,
            };

            await this.infoRepository.AddAsync(statisticInfo);
            await this.infoRepository.SaveChangesAsync();
        }

        public IEnumerable<PlayerStatisticViewModel> GetPlayerStatistics(string userId)
        {
            var statistics = this.statisticyRepository.All()
            .Where(x => x.UserId == userId)
            .Select(x => new PlayerStatisticViewModel
            {
                UserId = x.UserId,
                EventId = x.EventId,
                EventName = x.Event.Name,
                Date = x.Event.Date
                     .ToString(GlobalConstants.DateTimeFormat.DateFormat),
                GunInfo = x.Info
                .Select(gunInfo => new GunInfoStatisticViewModel
                {
                    GunId = gunInfo.GunId,
                    Energy = gunInfo.GunEnergy,
                    Gun = gunInfo.Gun.GunType.ToString() + " - " + gunInfo.Gun.Manufacture,
                }),
            }).ToList();

            return statistics;
        }

        public bool IsUpcoming()
        {
            var gameEvent = this.eventService.UpcomingEvent();

            if (gameEvent != null)
            {
                return true;
            }

            return false;
        }
    }
}
