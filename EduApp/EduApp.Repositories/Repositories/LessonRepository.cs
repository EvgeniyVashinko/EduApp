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
    internal sealed class LessonRepository : Repository<Lesson, Guid>, ILessonRepository
    {
        internal LessonRepository(DbContext dbContext) : base(dbContext) { }

        public PagedList<Lesson> GetPagedList(PageInfo pageInfo, Expression<Func<Lesson, bool>> predicate = null)
        {
            var query = MakeInclusions().Where(predicate ?? (x => true));
            var pageItems = query.SelectPage(pageInfo).ToList();

            return new PagedList<Lesson>(pageItems, query.Count(), pageInfo);
        }
    }
}
