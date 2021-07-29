namespace AirsoftApplication.Data.Models.Users
{
    using System;
    using System.Collections.Generic;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Comments;
    using AirsoftApplication.Data.Models.Guns;
    using AirsoftApplication.Data.Models.Images;
    using AirsoftApplication.Data.Models.Statistics;
    using AirsoftApplication.Data.Models.Votes;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commnents = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
            this.Guns = new HashSet<Gun>();
            this.Statistics = new HashSet<Statistic>();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public string PlayerName { get; set; }

        public Image ProfileImage { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Comment> Commnents { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<Gun> Guns { get; set; }

        public ICollection<Statistic> Statistics { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
