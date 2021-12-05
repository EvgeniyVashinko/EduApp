using System;

namespace EduApp.Core.Requests.Course
{
    public class CourseListRequest
    {
        public string Title { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public Guid ParticipantId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
