using System;

namespace EduApp.Core.Pagination
{
    public class PagedListBase
    {
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }

        public int TotalPages => TotalItems % PerPage == 0 ? TotalItems / PerPage : TotalItems / PerPage + 1;
        public bool CanNext => Page < TotalPages;
        public bool CanPrevious => Page > 1;

        public PagedListBase(int totalItems, PageInfo pageInfo)
        {
            if (totalItems < 0)
            {
                throw new ArgumentException($"{nameof(totalItems)} must be >= 0", nameof(totalItems));
            }

            TotalItems = totalItems;
            Page = pageInfo.Page;
            PerPage = pageInfo.PerPage;
        }
    }
}
