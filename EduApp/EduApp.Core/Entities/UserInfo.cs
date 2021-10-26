using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class UserInfo : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public byte Sex { get; set; }

        public string Email { get; set; }

        public byte[] Image { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}
