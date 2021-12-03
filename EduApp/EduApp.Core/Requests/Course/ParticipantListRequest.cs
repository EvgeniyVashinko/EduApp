using System;

namespace EduApp.Core.Requests.Course
{
    public class ParticipantListRequest
    {
        public Guid CourseId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
