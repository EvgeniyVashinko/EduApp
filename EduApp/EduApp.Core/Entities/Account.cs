using EduApp.Core.Common;
using System;
using System.Collections.Generic;

namespace EduApp.Core.Entities
{
    public class Account : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Homework> Homework { get; set; }

        public ICollection<Rewiew> Rewiews { get; set; }

        public ICollection<Course> MyStartedCourses { get; set; }

        public ICollection<Course> MyOwnCourses { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Guid UserInfoId { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
