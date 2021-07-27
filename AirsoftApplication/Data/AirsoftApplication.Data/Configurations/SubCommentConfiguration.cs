namespace AirsoftApplication.Data.Configurations
{
    using AirsoftApplication.Data.Models.Comments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SubCommentConfiguration : IEntityTypeConfiguration<SubComment>
    {
        public void Configure(EntityTypeBuilder<SubComment> subComment)
        {
            subComment
                .HasKey(x => x.Id);

            subComment
                .Property(x => x.CommentId)
                .IsRequired();

            subComment
                .Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode();
        }
    }
}
