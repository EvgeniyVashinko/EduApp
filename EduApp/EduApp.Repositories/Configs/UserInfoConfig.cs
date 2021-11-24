using EduApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduApp.Repositories.Configs
{
    public class UserInfoConfig : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable(nameof(UserInfo));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("UserInfoId");

            builder.HasOne(x => x.Account).WithOne(x => x.UserInfo).HasForeignKey<Account>(b => b.UserInfoId);
        }
    }
}
