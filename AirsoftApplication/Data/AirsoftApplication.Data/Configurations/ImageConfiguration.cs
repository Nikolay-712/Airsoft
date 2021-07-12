namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Images;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> image)
        {
            image
                .HasKey(x => x.Id);

            image
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            image
                .Property(x => x.ImageUrl)
                .IsRequired();

            image
                .Property(x => x.GuidingId)
                .IsRequired();
        }
    }
}
