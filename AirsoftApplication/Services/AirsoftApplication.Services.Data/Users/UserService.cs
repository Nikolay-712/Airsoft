namespace AirsoftApplication.Services.Data.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Services.Data.Images;
    using AirsoftApplication.Services.Data.Roles;
    using AirsoftApplication.Web.ViewModels.Administration.Users;
    using AirsoftApplication.Web.ViewModels.Guns;
    using AirsoftApplication.Web.ViewModels.Images;
    using AirsoftApplication.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Caching.Memory;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IImageService imageService;
        private readonly IRoleService roleService;
        private readonly IMemoryCache memoryCache;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IImageService imageService,
            IRoleService roleService,
            IMemoryCache memoryCache,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userRepository = userRepository;
            this.imageService = imageService;
            this.roleService = roleService;
            this.memoryCache = memoryCache;
            this.roleManager = roleManager;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = this.memoryCache.Get<IEnumerable<UserViewModel>>(GlobalConstants.UsersCacheKey);

            users = this.userRepository.All()
               .Select(user => new UserViewModel
               {
                   UserId = user.Id,
                   PlayerName = user.PlayerName,
                   CreatedOn = user.CreatedOn.ToString(GlobalConstants.DateTimeFormat.DateFormat),
                   Roles = user.Roles.Select(x => x.RoleId),
                   ProfileImageUrl = this.imageService.GetProfileImageUrl(user.Id),
                   Guns = user.Guns.Select(gun => new GunViewModel
                   {
                       GunId = gun.Id,
                       GunType = gun.GunType.ToString(),
                       Manufacture = gun.Manufacture,
                   }),
               }).ToList();

            this.UserRolesToString(users);

            var cacheOptions = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromDays(1));

            this.memoryCache.Set(GlobalConstants.UsersCacheKey, users, cacheOptions);

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

        public SetUserRoleViewModel GetPlayerInformation(string userId)
        {
            var user = this.GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            var userInfo = new SetUserRoleViewModel
            {
                PlayerName = user.PlayerName,
                ProfileImage = user.ProfileImageUrl,
                CreatedOn = user.CreatedOn,
                CurrentRoles = user.AllUserRoles,
                ApplicationRoles = this.roleService.GetApplicationRoles(),
            };

            return userInfo;
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
