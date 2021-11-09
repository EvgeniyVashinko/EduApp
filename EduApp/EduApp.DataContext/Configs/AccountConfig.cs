using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.DataContext.Configs
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("AccountId");

            builder.HasMany(x => x.Roles).WithMany(x => x.Accounts)
                .UsingEntity<AccountRole>(
                    right => right.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId),
                    left => left.HasOne<Account>().WithMany().HasForeignKey(x => x.AccountId),
                    join => join.ToTable("AccountRole"));
        }
    }
}
