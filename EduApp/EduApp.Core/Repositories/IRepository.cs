using EduApp.Core.Common;
using EduApp.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EduApp.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : BaseEntity<TKey>
    {
        TEntity Find(TKey id);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        PagedList<TEntity> GetPagedList(PageInfo pageInfo, Expression<Func<TEntity, bool>> predicate = null);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
