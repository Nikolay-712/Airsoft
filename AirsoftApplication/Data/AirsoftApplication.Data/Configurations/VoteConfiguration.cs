namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Votes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> vote)
        {
            vote
                .HasKey(x => x.Id);

            vote
                .Property(x => x.UserId)
                .IsRequired();

            vote
                .Property(x => x.Type)
                .IsRequired();
        }
    }
}
