namespace AirsoftApplication.Services.Data.Guns
{
    using System.Threading.Tasks;

    using AirsoftApplication.Web.ViewModels.Guns;

    public interface IGunService
    {
        Task AddGunAsync(string userId, InputGunViewModel input);
    }
}
