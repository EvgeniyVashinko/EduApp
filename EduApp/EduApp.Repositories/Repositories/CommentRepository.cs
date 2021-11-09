using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class CommentRepository : Repository<Comment, Guid>, ICommentRepository
    {
        internal CommentRepository(DbContext dbContext) : base(dbContext) { }
    }
}
