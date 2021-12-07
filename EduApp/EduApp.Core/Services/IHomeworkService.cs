using EduApp.Core.Requests.Homework;
using EduApp.Core.Responses.Homework;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface IHomeworkService
    {
        public Task<HomeworkResponse> GetHomework(GetHomeworkRequest request);
        public Task<HomeworkListResponse> GetHomeworkList(HomeworkListRequest request);
        public Task<HomeworkResponse> CreateHomework(CreateHomeworkRequest request);
        public Task<HomeworkResponse> UpdateHomework(UpdateHomeworkRequest request);
        public Task<HomeworkResponse> RemoveHomework(RemoveHomeworkRequest request);
    }
}
