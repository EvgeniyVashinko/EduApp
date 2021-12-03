using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EduApp.Repositories.Repositories
{
    internal sealed class AccountRepository : Repository<Account, Guid>, IAccountRepository
    {
        internal AccountRepository(DbContext context) : base(context) { }

        public Account FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return Find(x => x.Username.ToUpper() == username.ToUpper());
        }

        protected override IQueryable<Account> MakeInclusions()
        {
            return DbSet.Include(x => x.Roles)
                        .Include(x => x.UserInfo)
                        .ThenInclude(x => x.Account);
        }
    }
}
