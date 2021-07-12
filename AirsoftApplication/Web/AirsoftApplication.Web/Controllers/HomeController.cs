namespace AirsoftApplication.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Web.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //var user = await this.userManager.GetUserAsync(this.User);
            //await this.roleManager.CreateAsync(new ApplicationRole("Administrator"));

            //await this.userManager.AddToRoleAsync(user, "Administrator");


            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
