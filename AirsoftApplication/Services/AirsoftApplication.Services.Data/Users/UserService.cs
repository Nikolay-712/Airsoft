namespace AirsoftApplication.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Web.ViewModels.Guns;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IImageService imageService;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IImageService imageService,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userRepository = userRepository;
            this.imageService = imageService;
            this.roleManager = roleManager;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = this.userRepository.All()
                .Select(user => new UserViewModel
                {
                    UserId = user.Id,
                    PlayerName = user.PlayerName,
                    CreatedOn = user.CreatedOn.ToString("dd.MM.yyyy"),
                    Roles = user.Roles.Select(x => x.RoleId),
                    Guns = user.Guns.Select(gun => new GunViewModel
                    {
                        GunId = gun.Id,
                        GunType = gun.GunType.ToString(),
                        Manufacture = gun.Manufacture,
                    }),
                }).ToList();

            this.UserRolesToString(users);

            return users;
        }

        public UserViewModel GetUserById(string id)
        {
            return this.GetAllUsers()
                .FirstOrDefault(x => x.UserId == id);
        }

        public async Task UploadProfileImageAsync(string userId, InputImageViewModel input)
        {
            await this.imageService.UploadFileAsync(userId, input.Files);
        }

        private void UserRolesToString(IEnumerable<UserViewModel> users)
        {
            var userRoles = new StringBuilder();
            var allRoles = this.roleManager.Roles.ToList();

            foreach (var user in users)
            {
                foreach (var roleId in user.Roles)
                {
                    var role = allRoles.FirstOrDefault(x => x.Id == roleId).Name;

                    userRoles.Append(role).Append("/");
                }

                user.AllUserRoles = userRoles.ToString().TrimEnd('/');
                userRoles.Clear();

                user.ProfileImageUrl = this.imageService.GetProfileImageUrl(user.UserId);
            }
        }
    }
}
