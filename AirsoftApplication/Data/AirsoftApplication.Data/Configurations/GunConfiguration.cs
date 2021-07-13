namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Guns;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GunConfiguration : IEntityTypeConfiguration<Gun>
    {
        public void Configure(EntityTypeBuilder<Gun> gun)
        {
            gun
                .HasKey(x => x.Id);

            gun
                .Property(x => x.GunType)
                .IsRequired();

            gun
                .Property(x => x.Manufacture)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();
        }
    }
}
