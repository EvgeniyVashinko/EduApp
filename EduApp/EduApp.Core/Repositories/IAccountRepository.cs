using EduApp.Core.Entities;
using System;

namespace EduApp.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
        Account FindByUsername(string username);
    }
}
