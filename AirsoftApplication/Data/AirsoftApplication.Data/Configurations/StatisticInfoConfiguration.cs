namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Statistics;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StatisticInfoConfiguration : IEntityTypeConfiguration<StatisticInfo>
    {
        public void Configure(EntityTypeBuilder<StatisticInfo> info)
        {
            info
                .HasKey(x => x.Id);

            info
                .Property(x => x.StatisticId)
                .IsRequired();

            info
                .Property(x => x.GunId)
                .IsRequired();

            info
                .Property(x => x.GunEnergy)
                .IsRequired();
        }
    }
}
