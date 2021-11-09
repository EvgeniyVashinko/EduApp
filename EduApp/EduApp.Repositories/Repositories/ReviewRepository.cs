using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class ReviewRepository : Repository<Review, Guid>, IReviewRepository
    {
        internal ReviewRepository(DbContext dbContext) : base(dbContext) { }
    }
}
