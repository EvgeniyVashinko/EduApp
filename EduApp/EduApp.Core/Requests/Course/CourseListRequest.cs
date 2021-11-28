﻿namespace EduApp.Core.Requests.Course
{
    public class CourseListRequest
    {
        public string Title { get; set; } = string.Empty;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
