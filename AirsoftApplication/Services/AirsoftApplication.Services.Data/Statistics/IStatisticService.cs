namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Administration.Statistics;
    using AirsoftApplication.Web.ViewModels.Users;

    public interface IStatisticService
    {
        StatisticViewModel GetUserInfo(string userId);

        Task CreateStatisticAsync(StatisticViewModel model);
    }
}
