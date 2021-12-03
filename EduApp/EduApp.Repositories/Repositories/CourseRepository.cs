using EduApp.Core.Entities;
using EduApp.Core.Extensions;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EduApp.Repositories.Repositories
{
    internal sealed class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        internal CourseRepository(DbContext dbContext) : base(dbContext) { }

        protected override IQueryable<Course> MakeInclusions()
        {
            return DbSet.Include(x => x.Participants)
                        .ThenInclude(x => x.UserInfo)
                        .ThenInclude(x => x.Account);
        }
    }
}
