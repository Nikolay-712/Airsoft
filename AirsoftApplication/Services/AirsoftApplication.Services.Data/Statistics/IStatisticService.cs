namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Administration.Statistics;

    public interface IStatisticService
    {
        Task CreateStatisticAsync(StatisticViewModel model);
    }
}
