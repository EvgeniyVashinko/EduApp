using System;

namespace EduApp.Core.Requests.Review
{
    public class ReviewListRequest
    {
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
