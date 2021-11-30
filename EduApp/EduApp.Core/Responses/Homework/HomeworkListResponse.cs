using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.Homework
{
    public class HomeworkListResponse
    {
        public PagedList<HomeworkResponse> PagedList { get; set; }

        public HomeworkListResponse()
        {
        }

        public HomeworkListResponse(PagedList<Entities.Homework> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new HomeworkResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
