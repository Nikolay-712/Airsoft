namespace AirsoftApplication.Web.Controllers.Players
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Guns;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Web.Infrastructure;
    using AirsoftApplication.Web.ViewModels.Guns;
    using AirsoftApplication.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PlayersController : Controller
    {
        private readonly IGunService gunService;
        private readonly IUserService userService;

        public PlayersController(
            IGunService gunService,
            IUserService userService)
        {
            this.gunService = gunService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var player = this.userService
                .GetAllUsers()
                .FirstOrDefault(x => x.UserId == ClaimsPrincipalExtensions.Id(this.User));

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

            await this.gunService.AddGunAsync(ClaimsPrincipalExtensions.Id(this.User), input);

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

            await this.userService.UploadProfileImageAsync(ClaimsPrincipalExtensions.Id(this.User), input);
            return this.RedirectToAction("Index");
        }
    }
}
