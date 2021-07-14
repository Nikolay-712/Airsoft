namespace AirsoftApplication.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Users;
    using AirsoftApplication.Web.ViewModels.Guns;
    using AirsoftApplication.Web.ViewModels.Users;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = this.userRepository.All()
                .Select(user => new UserViewModel
                {
                    UserId = user.Id,
                    PlayerName = user.PlayerName,
                    Guns = user.Guns
                    .Select(gun => new GunViewModel
                    {
                        GunId = gun.Id,
                        GunType = gun.GunType.ToString(),
                        Manufacture = gun.Manufacture,
                    }),
                }).ToList();

            return users;
        }
    }
}
