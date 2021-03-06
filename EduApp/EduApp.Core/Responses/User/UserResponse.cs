using EduApp.Core.Entities;
using System;

namespace EduApp.Core.Responses.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public bool Sex { get; set; }
        public string Image { get; set; }
        public decimal AccountAmmount { get; set; }
        public Guid AccountId { get; set; }
        public UserResponse()
        {
        }

        public UserResponse(UserInfo user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Username = user.Account.Username;
            Birthday = user.Birthday;
            Sex = user.Sex;
            Image = user.Image;
            AccountAmmount = user.AccountAmmount;
            AccountId = user.AccountId;
        }
    }
}
