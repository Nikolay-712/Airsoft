namespace AirsoftApplication.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Guns;

    public class UserViewModel
    {
        public string UserId { get; set; }

        public string PlayerName { get; set; }

        public IEnumerable<GunViewModel> Guns { get; set; }
    }
}
