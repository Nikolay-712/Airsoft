namespace AirsoftApplication.Web.ViewModels.Administration.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Data.Models.Users;

    public class SetUserRoleViewModel
    {
        public string UserId { get; set; }

        public string PlayerName { get; set; }

        public string ProfileImage { get; set; }

        public string CreatedOn { get; set; }

        public string CurrentRoles { get; set; }

        public IEnumerable<ApplicationRole> ApplicationRoles { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
