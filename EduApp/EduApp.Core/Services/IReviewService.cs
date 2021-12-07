using EduApp.Core.Requests.Review;
using EduApp.Core.Responses.Review;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface IReviewService
    {
        public Task<ReviewResponse> GetReview(GetReviewRequest request);
        public Task<ReviewListResponse> GetReviewList(ReviewListRequest request);
        public Task<ReviewResponse> CreateReview(CreateReviewRequest request);
        public Task<ReviewResponse> UpdateReview(UpdateReviewRequest request);
        public Task<ReviewResponse> RemoveReview(RemoveReviewRequest request);
    }
}
