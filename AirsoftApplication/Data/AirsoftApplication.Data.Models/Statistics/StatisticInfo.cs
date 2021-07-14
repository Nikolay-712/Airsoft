namespace AirsoftApplication.Data.Models.Statistics
{
    using System;

    using AirsoftApplication.Data.Common.Models;
    using AirsoftApplication.Data.Models.Guns;

    public class StatisticInfo : BaseDeletableModel<string>
    {
        public StatisticInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string StatisticId { get; set; }

        public Statistic Statistic { get; set; }

        public string GunId { get; set; }

        public Gun Gun { get; set; }

        public double GunEnergy { get; set; }
    }
}
