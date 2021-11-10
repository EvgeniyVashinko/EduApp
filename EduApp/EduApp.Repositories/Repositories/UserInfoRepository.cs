using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class UserInfoRepository : Repository<UserInfo, Guid>, IUserInfoRepository
    {
        internal UserInfoRepository(DbContext dbContext) : base(dbContext) { }
    }
}
