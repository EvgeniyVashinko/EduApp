using EduApp.Core.Entities;
using EduApp.Core.Pagination;
using System;
using System.Linq.Expressions;

namespace EduApp.Core.Repositories
{
    public interface ILessonRepository : IRepository<Lesson, Guid>
    {
        PagedList<Lesson> GetPagedList(PageInfo pageInfo, Expression<Func<Lesson, bool>> predicate = null);
    }
}
