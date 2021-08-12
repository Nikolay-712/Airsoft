namespace AirsoftApplication.Web.ViewModels.Administration.Statistics
{
    using System.Collections.Generic;

    public class StatisticInfoViewModel
    {
        public string EventName { get; set; }

        public string Date { get; set; }

        public IEnumerable<InfoViewModel> Info { get; set; }
    }
}
