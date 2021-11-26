using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EduApp.Core.Pagination
{
    public class PagedList<T> : PagedListBase
    {
        public IReadOnlyList<T> Items { get; }

        public int From => (Page - 1) * PerPage + 1;
        public int To => From + Items.Count - 1;

        public PagedList(IList<T> items, int totalItems, PageInfo pageInfo) : base(totalItems, pageInfo)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Items = new ReadOnlyCollection<T>(items);
        }
    }
}
