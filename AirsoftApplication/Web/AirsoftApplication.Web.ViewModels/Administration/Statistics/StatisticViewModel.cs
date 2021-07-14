namespace AirsoftApplication.Web.ViewModels.Administration.Statistics
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Users;

    public class StatisticViewModel
    {
        public string UserId { get; set; }

        public string GunId { get; set; }

        public double GunEnergy { get; set; }

        public string EventId { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
