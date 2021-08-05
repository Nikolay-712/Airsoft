namespace AirsoftApplication.Web.ViewModels.Administration.Statistics
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AirsoftApplication.Web.ViewModels.Users;

    public class StatisticViewModel
    {
        public UserViewModel User { get; set; }

        public string UserId { get; set; }

        public string EventId { get; set; }

        [Required]
        public string GunId { get; set; }

        [Required]
        public double GunEnergy { get; set; }
    }
}
