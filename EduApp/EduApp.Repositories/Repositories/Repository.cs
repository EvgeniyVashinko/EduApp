using EduApp.Core.Common;
using EduApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduApp.Repositories.Repositories
{
    internal abstract class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DbContext context) => DbSet = context.Set<TEntity>();

        public TEntity Find(Tkey id)
        {
            return Find(x => x.Id.Equals(id));
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return MakeInclusions().FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> All()
        {
            return Filter(x => true);
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return MakeInclusions().Where(predicate).ToList();
        }

        public void Add(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Update(entity);
        }

        protected virtual IQueryable<TEntity> MakeInclusions() => DbSet;
    }
}
