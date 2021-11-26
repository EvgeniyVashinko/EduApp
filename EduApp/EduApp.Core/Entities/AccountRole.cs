using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class AccountRole : BaseEntity<Guid>
    {
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
    }
}
