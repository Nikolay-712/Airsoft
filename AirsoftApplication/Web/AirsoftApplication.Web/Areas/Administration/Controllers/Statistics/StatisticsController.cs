namespace AirsoftApplication.Web.Areas.Administration.Controllers.Statistics
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Statistics;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Web.ViewModels.Administration.Statistics;
    using Microsoft.AspNetCore.Mvc;

    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticService statisticService;
        private readonly IUserService userService;

        public StatisticsController(IStatisticService statisticService, IUserService userService)
        {
            this.statisticService = statisticService;
            this.userService = userService;
        }

        public IActionResult Index(string eventId)
        {
            var statisticModel = new StatisticViewModel
            {
                Users = this.userService.GetAllUsers(),
            };

            return this.View(statisticModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(StatisticViewModel model)
        {
            await this.statisticService.CreateStatisticAsync(model);
            return this.View();
        }
    }
}
