using EduApp.Core.Pagination;
using System;
using System.Linq;

namespace EduApp.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> SelectPage<T>(this IQueryable<T> items, PageInfo pageInfo)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (pageInfo is null)
            {
                throw new ArgumentNullException(nameof(pageInfo));
            }

            return items.Skip(pageInfo.PerPage * (pageInfo.Page - 1)).Take(pageInfo.PerPage);
        }
    }
}
