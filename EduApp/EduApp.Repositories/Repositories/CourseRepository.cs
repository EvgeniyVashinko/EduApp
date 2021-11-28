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

        public PagedList<Course> GetPagedList(PageInfo pageInfo, Expression<Func<Course, bool>> predicate = null)
        {
            var query = MakeInclusions().Where(predicate ?? (x => true));
            var pageItems = query.SelectPage(pageInfo).ToList();

            return new PagedList<Course>(pageItems, query.Count(), pageInfo);
        }
    }
}
