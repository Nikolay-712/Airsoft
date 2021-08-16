namespace AirsoftApplication.Web.ViewModels.Administration.Statistics
{
    using System.Collections.Generic;

    public class AllStatisticsViewModel : PagingViewModel
    {
        public IEnumerable<PlayerStatisticViewModel> PlayerStatistics { get; set; }
    }
}
