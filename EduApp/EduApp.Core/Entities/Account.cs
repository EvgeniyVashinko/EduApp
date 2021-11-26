using EduApp.Core.Common;
using EduApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EduApp.Core.Entities
{
    public class Account : BaseEntity<Guid>
    {
        public const int PasswordSaltLength = 128;

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

        public ICollection<Review> Rewiews { get; set; }

        public ICollection<Course> MyStartedCourses { get; set; }

        public ICollection<Course> MyOwnCourses { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public UserInfo UserInfo { get; set; }

        public bool VerifyPassword(string password)
        {
            return !string.IsNullOrEmpty(password) &&
                   PasswordHelper.ComputeHash(password, PasswordSalt) == Password;
        }

        public void ChangePassword(string password)
        {
            PasswordSalt = PasswordHelper.GenerateSalt(PasswordSaltLength);
            Password = PasswordHelper.ComputeHash(password, PasswordSalt);
        }

        public IEnumerable<Claim> GetClaims()
        {
            var claims = Roles.Select(x => new Claim(ClaimTypes.Role, x.Name)).ToList();
            claims.Add(new Claim(ClaimTypes.Name, Username));

            return claims;
        }
    }
}
