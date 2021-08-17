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
            return this.View();
        }

        [HttpPost]
        public IActionResult ScanBarCode(ScanerViewModel scaner)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (!this.statisticService.IsUpcoming())
            {
                return this.View("Index");
            }

            var user = this.barcodeService.ReadingBarCode(scaner.UserId);

            if (user == string.Empty)
            {
                return this.View("ScanBarCodeError");
            }

            return this.RedirectToAction("Index", new { userId = user });
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
    }
}
