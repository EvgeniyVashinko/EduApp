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
    }
}
