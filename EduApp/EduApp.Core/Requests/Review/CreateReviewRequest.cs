using System;

namespace EduApp.Core.Requests.Review
{
    public class CreateReviewRequest
    {
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
