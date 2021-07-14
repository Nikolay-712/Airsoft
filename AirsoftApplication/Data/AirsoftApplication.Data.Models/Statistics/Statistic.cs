namespace AirsoftApplication.Data.Models.Statistics
{
    using System;
    using System.Collections.Generic;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Events;
    using AirsoftApplication.Data.Models.Users;

    public class Statistic : BaseDeletableModel<string>
    {
        public Statistic()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string EventId { get; set; }

        public Event Event { get; set; }

        public IEnumerable<StatisticInfo> Info { get; set; }
    }
}
