using EduApp.Core.Requests.Course;
using EduApp.Core.Responses.Course;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface ICourseService
    {
        public interface IUserService
        {
            public Task<CourseResponse> GetUser(GetCourseRequest request);
            public Task<CourseResponse> CreateUser(CreateCourseRequest request);
            public Task<CourseResponse> UpdateUser(UpdateCourseRequest request);
            public Task<CourseResponse> RemoveUser(RemoveCourseRequest request);
        }
    }
}
