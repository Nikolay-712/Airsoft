namespace AirsoftApplication.Services.Data.Roles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Models.Users;

    public interface IRoleService
    {
        Task CreateRoleAsync(string roleName);

        IEnumerable<ApplicationRole> GetApplicationRoles();

        Task AddUserToRoleAsync(string userId, string roleName);
    }
}
