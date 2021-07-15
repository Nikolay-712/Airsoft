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
            var user = this.userService.GetUserById(userId);
            var userInfo = new SetUserRoleViewModel
            {
                PlayerName = user.PlayerName,
                CreatedOn = user.CreatedOn,
                CurrentRoles = user.AllUserRoles,
                ApplicationRoles = this.roleService.GetApplicationRoles(),
            };

            return this.View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> SetPlayerRole(SetUserRoleViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.roleService.AddUserToRoleAsync(model.UserId, model.RoleName);
            return this.RedirectToAction("AllPlayers");
        }
    }
}
