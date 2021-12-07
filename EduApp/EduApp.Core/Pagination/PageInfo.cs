using System;

namespace EduApp.Core.Pagination
{
    public class PageInfo
    {
        public int Page { get; set; }
        public int PerPage { get; set; }

        public PageInfo(int page = 1, int perPage = int.MaxValue)
        {
            if (page <= 0)
            {
                throw new ArgumentException($"{nameof(page)} must be more than 0", nameof(page));
            }

            if (perPage <= 0)
            {
                throw new ArgumentException($"{nameof(perPage)} must be more than 0", nameof(page));
            }

            Page = page;
            PerPage = perPage;
        }
    }
}
