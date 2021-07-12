namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Events;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> gameEvent)
        {
            gameEvent
                .HasKey(x => x.Id);

            gameEvent
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            gameEvent
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode();

            gameEvent
                .Property(x => x.FieldId)
                .IsRequired();
        }
    }
}
