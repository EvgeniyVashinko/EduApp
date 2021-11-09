using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        internal CategoryRepository(DbContext dbContext) : base(dbContext) { }
    }
}
