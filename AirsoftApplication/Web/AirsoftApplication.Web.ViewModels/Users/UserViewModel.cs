namespace AirsoftApplication.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Administration.Contacts;
    using AirsoftApplication.Web.ViewModels.Guns;
    using AirsoftApplication.Web.ViewModels.Images;

    public class UserViewModel
    {
        public string UserId { get; set; }

        public string PlayerName { get; set; }

        public string ProfileImageUrl { get; set; }

        public string CreatedOn { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string AllUserRoles { get; set; }

        public IEnumerable<GunViewModel> Guns { get; set; }

        public InputGunViewModel Input { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
