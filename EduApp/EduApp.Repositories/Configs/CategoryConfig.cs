using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CategoryId");

            builder.HasMany(x => x.Courses).WithMany(x => x.Categories)
                .UsingEntity<CourseCategory>(
                    right => right.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId),
                    left => left.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId),
                    join => join.ToTable("CourseCategory"));
        }
    }
}
