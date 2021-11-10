using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
        internal CourseRepository(DbContext dbContext) : base(dbContext) { }
    }
}
