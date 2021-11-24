using System;

namespace EduApp.Core.Requests.User
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public bool Sex { get; set; }
        public byte[] Image { get; set; }
    }
}
