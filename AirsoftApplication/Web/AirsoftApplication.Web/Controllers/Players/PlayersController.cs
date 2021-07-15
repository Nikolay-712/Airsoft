namespace AirsoftApplication.Web.Controllers.Players
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Guns;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Web.ViewModels.Guns;
    using AirsoftApplication.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : Controller
    {
        private readonly IGunService gunService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public PlayersController(
            IGunService gunService,
            IUserService userService,
            UserManager<ApplicationUser> userManager)
        {
            this.gunService = gunService;
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var playerId = await this.GetCurrentUserId();

            var player = this.userService
                .GetAllUsers()
                .FirstOrDefault(x => x.UserId == playerId);

            return this.View(player);
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

        public IActionResult UploadProfileImage()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(InputImageViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.userService.UploadProfileImageAsync(await this.GetCurrentUserId(), input);
            return this.RedirectToAction("Index");
        }

        private async Task<string> GetCurrentUserId()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            return user.Id;
        }
    }
}
