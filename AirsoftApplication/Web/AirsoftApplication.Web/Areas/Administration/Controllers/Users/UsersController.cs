namespace AirsoftApplication.Web.Areas.Administration.Controllers.Users
{
    using System.Threading.Tasks;

    using AirsoftApplication.Services.Data.Roles;
    using AirsoftApplication.Services.Data.Users;
    using AirsoftApplication.Web.ViewModels.Administration.Users;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdministrationController
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UsersController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public IActionResult AllPlayers()
        {
            var players = this.userService.GetAllUsers();
            return this.View(players);
        }

        public IActionResult SetPlayerRole(string userId)
        {
            var userInfo = this.userService.GetPlayerInformation(userId);

            if (userInfo == null)
            {
                return this.RedirectToAction("AllPlayers");
            }

            return this.View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> SetPlayerRole(SetUserRoleViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(this.userService.GetPlayerInformation(model.UserId));
            }

            await this.roleService.AddUserToRoleAsync(model.UserId, model.RoleName);
            return this.RedirectToAction("AllPlayers");
        }

        public IActionResult RemovePlayerRole(string userId)
        {
            var userInfo = this.userService.GetPlayerInformation(userId);

            if (userInfo == null)
            {
                return this.RedirectToAction("AllPlayers");
            }

            return this.View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePlayerRole(SetUserRoleViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(this.userService.GetPlayerInformation(model.UserId));
            }

            await this.roleService.RemoveUserRoleAsync(model.UserId, model.RoleName);
            return this.RedirectToAction("AllPlayers");
        }
    }
}
