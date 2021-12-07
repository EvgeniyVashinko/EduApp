using EduApp.Core.Entities;
using System;

namespace EduApp.Core.Responses.Categories
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CategoryResponse() { }

        public CategoryResponse(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
