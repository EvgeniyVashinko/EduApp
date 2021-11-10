using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class RoleRepository : Repository<Role, Guid>, IRoleRepository
    {
        internal RoleRepository(DbContext dbContext) : base(dbContext) { }
    }
}
