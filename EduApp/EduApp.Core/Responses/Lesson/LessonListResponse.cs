using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.Lesson
{
    public class LessonListResponse
    {
        public PagedList<LessonResponse> PagedList { get; set; }

        public LessonListResponse()
        {
        }

        public LessonListResponse(PagedList<Entities.Lesson> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new LessonResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
