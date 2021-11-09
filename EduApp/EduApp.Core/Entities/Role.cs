using EduApp.Core.Common;
using System;
using System.Collections.Generic;

namespace EduApp.Core.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
