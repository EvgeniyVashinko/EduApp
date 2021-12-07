using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class UserInfo : BaseEntity<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public bool Sex { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public decimal AccountAmmount { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}
