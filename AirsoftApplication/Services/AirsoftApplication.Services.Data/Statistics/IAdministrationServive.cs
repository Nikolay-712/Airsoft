namespace AirsoftApplication.Services.Data.Statistics
{
    using System.Collections.Generic;

    using AirsoftApplication.Web.ViewModels.Administration.Dashboard;
    using AirsoftApplication.Web.ViewModels.Administration.Users;

    public interface IAdministrationServive
    {
        AdministrationStatisticViewModel GetStatistic();

        IEnumerable<UserStatisticViewModel> GetPlayerStatistics();
    }
}
