namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Administration.Statistics;

    public interface IStatisticService
    {
        StatisticViewModel GetUserInfo(string userId);

        Task CreateStatisticAsync(StatisticViewModel model);

        IEnumerable<StatisticInfoViewModel> GetUserStatistic(string userId);
    }
}
