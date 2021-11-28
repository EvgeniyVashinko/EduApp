using EduApp.Core.Entities;
using EduApp.Core.Pagination;
using System;
using System.Linq.Expressions;

namespace EduApp.Core.Repositories
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
        public PagedList<Review> GetPagedList(PageInfo pageInfo, Expression<Func<Review, bool>> predicate = null);
    }
}
