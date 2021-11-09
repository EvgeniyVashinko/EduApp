using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class LessonRepository : Repository<Lesson, Guid>, ILessonRepository
    {
        internal LessonRepository(DbContext dbContext) : base(dbContext) { }
    }
}
