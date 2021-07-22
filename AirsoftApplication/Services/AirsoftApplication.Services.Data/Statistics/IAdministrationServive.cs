namespace AirsoftApplication.Services.Data.Statistics
{
    using AirsoftApplication.Web.ViewModels.Administration.Dashboard;

    public interface IAdministrationServive
    {
        AdministrationStatisticViewModel GetStatistic();
    }
}
