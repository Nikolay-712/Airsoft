namespace AirsoftApplication.Services.Data.Guns
{
    using System.Threading.Tasks;

    using AirsoftApplication.Data.Common.Repositories;
    using AirsoftApplication.Data.Models.Guns;
    using AirsoftApplication.Web.ViewModels.Guns;

    public class GunService : IGunService
    {
        private readonly IDeletableEntityRepository<Gun> gunRepository;

        public GunService(IDeletableEntityRepository<Gun> gunRepository)
        {
            this.gunRepository = gunRepository;
        }

        public async Task AddGunAsync(string userId, InputGunViewModel input)
        {
            var gun = new Gun
            {
                GunType = input.GunType,
                Manufacture = input.Manufacture,
                UserId = userId,
            };

            await this.gunRepository.AddAsync(gun);
            await this.gunRepository.SaveChangesAsync();
        }
    }
}
