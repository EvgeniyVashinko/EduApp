using EduApp.Core.Pagination;
using System.Linq;

namespace EduApp.Core.Responses.User
{
    public class UserListResponse
    {
        public PagedList<UserResponse> PagedList { get; set; }

        public UserListResponse()
        {
        }

        public UserListResponse(PagedList<Entities.UserInfo> pagedList)
        {
            PagedList = new(pagedList.Items.Select(x => new UserResponse(x)).ToList(), pagedList.TotalItems, new PageInfo(pagedList.Page, pagedList.PerPage));
        }
    }
}
