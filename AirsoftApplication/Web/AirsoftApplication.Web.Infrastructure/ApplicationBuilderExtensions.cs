namespace AirsoftApplication.Web.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        private static readonly string[] ApplicationRoles = new string[]
        {
            GlobalConstants.ApplicationRole.AdministratorRoleName,
            GlobalConstants.ApplicationRole.SoldierRoleName,
            GlobalConstants.ApplicationRole.CaptainRoleName,
        };

        public static void SeedApplicationRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            foreach (var roleName in ApplicationRoles)
            {
                Task.Run(async () =>
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        var role = new ApplicationRole { Name = roleName };
                        await roleManager.CreateAsync(role);

                        if (roleName == GlobalConstants.ApplicationRole.AdministratorRoleName)
                        {
                            const string adminEmail = "admin@abv.bg";
                            const string adminPassword = "admin123";

                            var user = new ApplicationUser
                            {
                                Email = adminEmail,
                                UserName = adminEmail,
                                PlayerName = "Admin",
                            };

                            await userManager.CreateAsync(user, adminPassword);
                            await userManager.AddToRoleAsync(user, GlobalConstants.ApplicationRole.AdministratorRoleName);
                        }
                    }
                }).GetAwaiter().GetResult();
            }
        }
    }
}
