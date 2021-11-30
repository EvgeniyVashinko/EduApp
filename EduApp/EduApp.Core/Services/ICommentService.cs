using EduApp.Core.Requests.Comment;
using EduApp.Core.Responses.Comment;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface ICommentService
    {
        public Task<CommentResponse> GetComment(GetCommentRequest request);
        public Task<CommentListResponse> GetCommentList(CommentListRequest request);
        public Task<CommentResponse> CreateComment(CreateCommentRequest request);
        public Task<CommentResponse> UpdateComment(UpdateCommentRequest request);
        public Task<CommentResponse> RemoveComment(RemoveCommentRequest request);
    }
}
