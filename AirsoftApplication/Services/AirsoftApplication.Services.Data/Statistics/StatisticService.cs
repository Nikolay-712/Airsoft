namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Statistics;
    using AirsoftApplication.Web.ViewModels.Administration.Statistics;

    public class StatisticService : IStatisticService
    {
        private readonly IDeletableEntityRepository<Statistic> statisticyRepository;
        private readonly IDeletableEntityRepository<StatisticInfo> infoRepository;

        public StatisticService(
            IDeletableEntityRepository<Statistic> statisticyRepository,
            IDeletableEntityRepository<StatisticInfo> infoRepository)
        {
            this.statisticyRepository = statisticyRepository;
            this.infoRepository = infoRepository;
        }

        public async Task CreateStatisticAsync(StatisticViewModel model)
        {
            var exists = this.statisticyRepository.All()
                .Any(x => x.EventId == model.EventId && x.UserId == model.UserId);

            string statisticId = string.Empty;

            if (!exists)
            {
                var statistic = new Statistic
                {
                    UserId = model.UserId,
                    EventId = model.EventId,
                };

                //await this.statisticyRepository.AddAsync(statistic);
                //await this.statisticyRepository.SaveChangesAsync();

                statisticId = statistic.Id;
            }

            if (string.IsNullOrEmpty(statisticId))
            {
                statisticId = this.statisticyRepository.All()
                     .Where(x => x.EventId == model.EventId && x.UserId == model.UserId)
                     .Select(x => x.Id).FirstOrDefault();
            }

            var statisticInfo = new StatisticInfo
            {
                StatisticId = statisticId,
                GunId = model.GunId,
                GunEnergy = model.GunEnergy,
            };

            //await this.infoRepository.AddAsync(statisticInfo);
            //await this.infoRepository.SaveChangesAsync();
        }
    }
}
