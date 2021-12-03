using EduApp.Core.Requests.Course;
using EduApp.Core.Responses.Course;
using EduApp.Core.Responses.User;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface ICourseService
    {
        public Task<CourseResponse> GetCourse(GetCourseRequest request);
        public Task<CourseListResponse> GetCourseList(CourseListRequest request);
        public Task<CourseResponse> CreateCourse(CreateCourseRequest request);
        public Task<CourseResponse> UpdateCourse(UpdateCourseRequest request);
        public Task<CourseResponse> RemoveCourse(RemoveCourseRequest request);
        public Task<CourseResponse> AddParticipant(ParticipantRequest request);
        public Task<CourseResponse> RemoveParticipant(ParticipantRequest request);
        public Task<UserListResponse> GetCourseParticipantList(ParticipantListRequest request);
    }
}
