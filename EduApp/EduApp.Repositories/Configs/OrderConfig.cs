using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("OrderId");

            builder.HasOne(x => x.Course);
            builder.HasOne(x => x.Account);
        }
    }
}
