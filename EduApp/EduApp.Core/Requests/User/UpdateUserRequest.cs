using System;

namespace EduApp.Core.Requests.User
{
    public class UpdateUserRequest : CreateUserRequest
    {
        public Guid Id { get; set; }
    }
}
