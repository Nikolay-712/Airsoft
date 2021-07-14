namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Statistics;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> statistic)
        {
            statistic
                .HasKey(x => x.Id);

            statistic
                .Property(x => x.UserId)
                .IsRequired();

            statistic
                .Property(x => x.EventId)
                .IsRequired();
        }
    }
}
