using System;

namespace EduApp.Core.Entities
{
    public class AccountRole
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
