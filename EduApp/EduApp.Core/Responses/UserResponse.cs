using EduApp.Core.Entities;
using System;

namespace EduApp.Core.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public bool Sex { get; set; }
        public byte[] Image { get; set; }
        public UserResponse()
        {
        }

        public UserResponse(UserInfo user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            UserName = user.Account.Username;
            Birthday = user.Birthday;
            Sex = user.Sex;
            Image = user.Image;
        }
    }
}
