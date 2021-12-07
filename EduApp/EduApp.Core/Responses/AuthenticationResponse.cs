using System;

namespace EduApp.Core.Responses
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public Guid AccountId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
