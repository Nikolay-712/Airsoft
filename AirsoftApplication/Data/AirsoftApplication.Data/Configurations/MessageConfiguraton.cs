namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Contacts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MessageConfiguraton : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> message)
        {
            message
                .HasKey(x => x.Id);

            message
                .Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            message
                .Property(x => x.Email)
                .IsRequired();

            message
                .Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            message
                .Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode();
        }
    }
}
