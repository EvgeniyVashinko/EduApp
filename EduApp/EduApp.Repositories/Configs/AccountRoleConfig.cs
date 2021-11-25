using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class AccountRoleConfig : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.ToTable(nameof(AccountRole));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("AccountRoleId");
        }
    }
}
