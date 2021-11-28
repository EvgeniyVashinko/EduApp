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
    internal sealed class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        internal ReviewRepository(DbContext dbContext) : base(dbContext) { }

        public PagedList<Review> GetPagedList(PageInfo pageInfo, Expression<Func<Review, bool>> predicate = null)
        {
            var query = MakeInclusions().Where(predicate ?? (x => true));
            var pageItems = query.SelectPage(pageInfo).ToList();

            return new PagedList<Review>(pageItems, query.Count(), pageInfo);
        }
    }
}
