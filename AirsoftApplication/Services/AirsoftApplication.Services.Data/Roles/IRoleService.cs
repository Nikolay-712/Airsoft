namespace AirsoftApplication.Services.Data.Roles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;

    public interface IRoleService
    {
        IEnumerable<ApplicationRole> GetApplicationRoles();

        Task AddUserToRoleAsync(string userId, string roleName);

        Task RemoveUserRoleAsync(string userId, string roleName);
    }
}
