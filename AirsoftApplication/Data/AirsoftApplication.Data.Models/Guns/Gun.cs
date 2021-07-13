namespace AirsoftApplication.Data.Models.Guns
{
    using System;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Users;

    public class Gun : BaseDeletableModel<string>
    {
        public Gun()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public GunType GunType { get; set; }

        public string Manufacture { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
