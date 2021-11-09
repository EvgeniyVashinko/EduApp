using EduApp.Core.Entities;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduApp.Repositories.Repositories
{
    internal sealed class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        internal OrderRepository(DbContext dbContext) : base(dbContext) { }
    }
}
