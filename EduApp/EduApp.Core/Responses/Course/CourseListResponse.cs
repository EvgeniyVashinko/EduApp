using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.Course
{
    public class CourseListResponse
    {
        public PagedList<CourseResponse> PagedList { get; set; }

        public CourseListResponse()
        {
        }

        public CourseListResponse(PagedList<Entities.Course> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new CourseResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
