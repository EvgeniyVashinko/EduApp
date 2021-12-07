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
    internal sealed class CommentRepository : Repository<Comment, Guid>, ICommentRepository
    {
        internal CommentRepository(DbContext dbContext) : base(dbContext) { }
    }
}
