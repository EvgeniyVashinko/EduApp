using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class HomeworkRepository : Repository<Homework, Guid>, IHomeworkRepository
    {
        internal HomeworkRepository(DbContext dbContext) : base(dbContext) { }
    }
}
