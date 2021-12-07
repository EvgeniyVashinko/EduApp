using EduApp.Core.Entities;
using EduApp.Core.Pagination;
using System;
using System.Linq.Expressions;

namespace EduApp.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {

    }
}
