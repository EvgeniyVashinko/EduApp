using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EduApp.Repositories.Repositories
{
    internal sealed class UserInfoRepository : Repository<UserInfo, Guid>, IUserInfoRepository
    {
        internal UserInfoRepository(DbContext dbContext) : base(dbContext) { }

        protected override IQueryable<UserInfo> MakeInclusions()
        {
            return DbSet.Include(x => x.Account)
                        .ThenInclude(x => x.Roles);
        }
    }
}
