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

        protected override IQueryable<Review> MakeInclusions()
        {
            return DbSet.Include(x => x.Account);
        }
    }
}
