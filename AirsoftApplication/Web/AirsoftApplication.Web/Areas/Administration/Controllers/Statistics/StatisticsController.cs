namespace AirsoftApplication.Web.Areas.Administration.Controllers.Statistics
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.BarCode;
    using AirsoftApplication.Services.Data.Statistics;
    using AirsoftApplication.Web.ViewModels.Administration.Statistics;
    using Microsoft.AspNetCore.Mvc;

    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticService statisticService;
        private readonly IBarCodeService barcodeService;

        public StatisticsController(IStatisticService statisticService, IBarCodeService barcodeService)
        {
            this.statisticService = statisticService;
            this.barcodeService = barcodeService;
        }

        public IActionResult ScanBarCode()
        {
            var userId = this.barcodeService.ReadingBarCode("29011e3c-99d8-404e-9bd8-54c9df73a00f");

            if (userId == string.Empty)
            {
                return this.View("ScanBarCodeError");
            }

            return this.RedirectToAction("Index", new { userId = userId });
        }

        public IActionResult Index(string userId)
        {
            var statisticInfo = this.statisticService.GetUserInfo(userId);
            return this.View(statisticInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string userId, StatisticViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var statisticInfo = this.statisticService.GetUserInfo(userId);
                return this.View(statisticInfo);
            }

            await this.statisticService.CreateStatisticAsync(model);

            return this.RedirectToAction("ScanBarCode");
        }

        public IActionResult ShowStatisticInfo(string userId)
        {
            var playerStatistic = this.statisticService
                .GetUserStatistic(userId);

            if (playerStatistic == null)
            {
                return this.NotFound();
            }

            return this.View(playerStatistic);
        }
    }
}
