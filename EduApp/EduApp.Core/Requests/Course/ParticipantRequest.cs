using System;

namespace EduApp.Core.Requests.Course
{
    public class ParticipantRequest
    {
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
    }
}
