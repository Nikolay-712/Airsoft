namespace AirsoftApplication.Web.ViewModels.Administration.Users
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Administration.Statistics;

    public class UserStatisticViewModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string ProfileImageUrl { get; set; }

        public IEnumerable<StatisticInfoViewModel> StatisticInfos { get; set; }
    }
}
