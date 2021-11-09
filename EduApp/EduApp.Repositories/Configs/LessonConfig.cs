using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable(nameof(Lesson));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("LessonId");
        }
    }
}
