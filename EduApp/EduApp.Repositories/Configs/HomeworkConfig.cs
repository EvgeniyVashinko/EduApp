using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class HomeworkConfig : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable(nameof(Homework));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("HomeworkId");

            builder.HasOne(x => x.Account).WithMany(x => x.Homeworks);
            builder.HasOne(x => x.Lesson).WithMany(x => x.Homeworks);
        }
    }
}
