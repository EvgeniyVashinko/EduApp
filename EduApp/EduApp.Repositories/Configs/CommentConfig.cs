using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(nameof(Comment));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CommentId");

            builder.HasOne(x => x.Account).WithMany(x => x.Comments);
            builder.HasOne(x => x.Lesson).WithMany(x => x.Comments);
        }
    }
}
