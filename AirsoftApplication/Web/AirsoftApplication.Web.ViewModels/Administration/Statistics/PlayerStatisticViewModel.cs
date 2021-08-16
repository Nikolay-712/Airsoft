namespace AirsoftApplication.Web.ViewModels.Administration.Statistics
{
    using System.Collections.Generic;

    public class PlayerStatisticViewModel
    {
        public string UserId { get; set; }

        public string EventId { get; set; }

        public string EventName { get; set; }

        public string Date { get; set; }

        public IEnumerable<GunInfoStatisticViewModel> GunInfo { get; set; }
    }
}
