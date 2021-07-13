namespace AirsoftApplication.Web.Controllers.Players
{
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Guns;
    using AirsoftApplication.Web.ViewModels.Guns;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : Controller
    {
        private readonly IGunService gunService;
        private readonly UserManager<ApplicationUser> userManager;

        public PlayersController(IGunService gunService, UserManager<ApplicationUser> userManager)
        {
            this.gunService = gunService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AddGun()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGun(InputGunViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.gunService.AddGunAsync(await this.GetCurrentUserId(), input);

            return this.RedirectToAction("Index");
        }

        private async Task<string> GetCurrentUserId()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            return user.Id;
        }
    }
}
