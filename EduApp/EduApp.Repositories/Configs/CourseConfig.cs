using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CourseId");

            builder.HasMany(x => x.Lessons).WithOne(x => x.Course);
            builder.HasMany(x => x.Rewiews).WithOne(x => x.Course);
        }
    }
}
