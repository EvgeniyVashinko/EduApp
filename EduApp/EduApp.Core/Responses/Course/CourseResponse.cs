using EduApp.Core.Entities;
using EduApp.Core.Responses.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduApp.Core.Responses.Course
{
    public class CourseResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CategoryResponse> CategoriesObj { get; set; }

        public CourseResponse()
        {
        }

        public CourseResponse(Entities.Course course)
        {
            Id = course.Id;
            AccountId = course.OwnerId;
            Title = course.Title;
            Description = course.Description;
            Price = course.Price;
            OwnerId = course.OwnerId;
            CreationDate = course.CreationDate;
            UpdatedDate = course.UpdatedDate;
            IsActive = course.IsActive;
            CategoriesObj = course.Categories.Select(x => new CategoryResponse(x)).ToList();
        }
    }
}
