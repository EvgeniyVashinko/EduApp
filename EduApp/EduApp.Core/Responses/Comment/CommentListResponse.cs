using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.Comment
{
    public class CommentListResponse
    {
        public PagedList<CommentResponse> PagedList { get; set; }

        public CommentListResponse()
        {
        }

        public CommentListResponse(PagedList<Entities.Comment> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new CommentResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
