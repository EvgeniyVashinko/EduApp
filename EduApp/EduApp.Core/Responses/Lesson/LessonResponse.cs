using System;

namespace EduApp.Core.Responses.Lesson
{
    public class LessonResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RecommendedTime { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public LessonResponse()
        {
        }

        public LessonResponse(Entities.Lesson lesson)
        {
            Id = lesson.Id;
            CourseId = lesson.CourseId;
            Title = lesson.Title;
            Description = lesson.Description;
            RecommendedTime = lesson.RecommendedTime;
            CreationDate = lesson.CreationDate;
            UpdatedDate = lesson.UpdatedDate;
        }
    }
}
