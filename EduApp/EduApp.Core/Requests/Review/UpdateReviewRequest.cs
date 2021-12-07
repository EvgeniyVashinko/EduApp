using System;

namespace EduApp.Core.Requests.Review
{
    public class UpdateReviewRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
