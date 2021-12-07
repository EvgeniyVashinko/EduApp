using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.Order
{
    public class OrderListResponse
    {
        public PagedList<OrderResponse> PagedList { get; set; }

        public OrderListResponse()
        {
        }

        public OrderListResponse(PagedList<Entities.Order> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new OrderResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
