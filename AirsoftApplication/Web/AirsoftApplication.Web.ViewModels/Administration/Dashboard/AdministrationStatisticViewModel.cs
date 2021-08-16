namespace AirsoftApplication.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Events;
    using AirsoftApplication.Web.ViewModels.Users;

    public class AdministrationStatisticViewModel : PagingViewModel
    {
        public int RegisteredUsers { get; set; }

        public int UnreadMessages { get; set; }

        public int OrganizedEvents { get; set; }

        public int UsersInTeamRole { get; set; }

        public IEnumerable<MostRatedEventViewModel> Events { get; set; }

        public IEnumerable<UserViewModel> TeamPlayers { get; set; }
    }
}
