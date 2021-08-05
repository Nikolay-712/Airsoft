namespace AirsoftApplication.Services.Data.Roles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.BarCode;
    using Microsoft.AspNetCore.Identity;

    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBarCodeService barCodeService;

        public RoleService(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IBarCodeService barCodeService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.barCodeService = barCodeService;
        }

        public IEnumerable<ApplicationRole> GetApplicationRoles()
        {
            return this.roleManager.Roles.ToList();
        }

        public async Task AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (!await this.roleManager.RoleExistsAsync(roleName))
            {
                await this.roleManager.CreateAsync(new ApplicationRole(roleName));
            }

            var userRoles = await this.userManager.GetRolesAsync(user);

            if (!userRoles.Contains(roleName))
            {
                await this.userManager.AddToRoleAsync(user, roleName);

                if (roleName == GlobalConstants.ApplicationRole.SoldierRoleName ||
                    roleName == GlobalConstants.ApplicationRole.CaptainRoleName)
                {
                    this.barCodeService.CreateBarCode(userId, roleName);
                }
            }
        }

        public async Task RemoveUserRoleAsync(string userId, string roleName)
        {
            this.barCodeService.ReadingBarCode(userId);

            var user = await this.userManager.FindByIdAsync(userId);
            await this.userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
