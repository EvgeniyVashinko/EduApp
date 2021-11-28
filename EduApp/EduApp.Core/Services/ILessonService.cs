using EduApp.Core.Requests.Lesson;
using EduApp.Core.Responses.Lesson;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface ILessonService
    {
        public Task<LessonResponse> GetLesson(GetLessonRequest request);
        public Task<LessonListResponse> GetLessonList(LessonListRequest request);
        public Task<LessonResponse> CreateLesson(CreateLessonRequest request);
        public Task<LessonResponse> UpdateLesson(UpdateLessonRequest request);
        public Task<LessonResponse> RemoveLesson(RemoveLessonRequest request);
    }
}
