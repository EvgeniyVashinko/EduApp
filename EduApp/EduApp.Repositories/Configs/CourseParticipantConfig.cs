using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class CourseParticipantConfig : IEntityTypeConfiguration<CourseParticipants>
    {
        public void Configure(EntityTypeBuilder<CourseParticipants> builder)
        {
            builder.ToTable(nameof(CourseParticipants));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CourseParticipantsId");
        }
    }
}
