using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace EduApp.Repositories
{
    internal class AppContext : DbContext
    {
        internal AppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
