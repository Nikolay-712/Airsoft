namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Events;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BattlefieldConfiguration : IEntityTypeConfiguration<Battlefield>
    {
        public void Configure(EntityTypeBuilder<Battlefield> field)
        {
            field
                .HasKey(x => x.Id);

            field
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            field
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode();

            field
                .Property(x => x.Location)
                .IsRequired();
        }
    }
}
