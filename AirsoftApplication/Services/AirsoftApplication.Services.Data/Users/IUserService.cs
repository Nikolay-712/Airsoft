namespace AirsoftApplication.Services.Data.Users
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Users;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
    }
}
