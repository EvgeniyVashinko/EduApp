using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class Order : BaseEntity
    {
        public decimal Sum { get; set; }

        public DateTime CreationalDate { get; set; }

        public Guid AccountId { get; set; }
        
        public Account Account { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}
