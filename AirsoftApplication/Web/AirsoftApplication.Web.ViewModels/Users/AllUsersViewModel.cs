namespace AirsoftApplication.Web.ViewModels.Users
{
    using System.Collections.Generic;

    public class AllUsersViewModel : PagingViewModel
    {
        public IEnumerable<UserViewModel> Players { get; set; }
    }
}
