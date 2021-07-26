namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Comments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment
                .HasKey(x => x.Id);

            comment
                .Property(x => x.EventId)
                .IsRequired();

            comment
                .Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode();
        }
    }
}
