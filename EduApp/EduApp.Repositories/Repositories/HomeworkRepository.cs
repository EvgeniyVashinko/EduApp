using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EduApp.Repositories.Repositories
{
    internal sealed class HomeworkRepository : Repository<Homework, Guid>, IHomeworkRepository
    {
        internal HomeworkRepository(DbContext dbContext) : base(dbContext) { }

        protected override IQueryable<Homework> MakeInclusions()
        {
            return DbSet.Include(x => x.Lesson)
                        .Include(x => x.Account);
        }
    }
}
