using System;

namespace EduApp.Core.Responses.Homework
{
    public class HomeworkResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LessonId { get; set; }
        public string Answer { get; set; }
        public string Url { get; set; }
        public int Mark { get; set; }
        public string LessonName { get; set; }
        public string Username { get; set; }

        public HomeworkResponse()
        {
        }

        public HomeworkResponse(Entities.Homework homework)
        {
            Id = homework.Id;
            AccountId = homework.AccountId;
            LessonId = homework.LessonId;
            Answer = homework.Answer;
            Url = homework.Url;
            Mark = homework.Mark;
            LessonName = homework.Lesson.Title;
            Username = homework.Account.Username;
        }
    }
}
