namespace AirsoftApplication.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();

        Task UploadProfileImageAsync(string userId, InputImageViewModel input);

        UserViewModel GetUserById(string id);
    }
}
