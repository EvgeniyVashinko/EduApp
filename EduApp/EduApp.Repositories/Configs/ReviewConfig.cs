using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable(nameof(Review));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ReviewId");

            builder.HasOne(x => x.Account).WithMany(x => x.Rewiews);
        }
    }
}
