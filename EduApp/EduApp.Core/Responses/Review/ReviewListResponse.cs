using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.Review
{
    public class ReviewListResponse
    {
        public PagedList<ReviewResponse> PagedList { get; set; }

        public ReviewListResponse()
        {
        }

        public ReviewListResponse(PagedList<Entities.Review> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new ReviewResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
