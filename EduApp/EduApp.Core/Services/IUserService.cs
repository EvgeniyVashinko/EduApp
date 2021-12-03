using EduApp.Core.Requests.User;
using EduApp.Core.Responses.User;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface IUserService
    {
        public Task<UserListResponse> GetUserList(UserListRequest request);
        public Task<UserResponse> GetUser(GetUserRequest request);
        public Task<UserResponse> CreateUser(CreateUserRequest request);
        public Task<UserResponse> UpdateUser(UpdateUserRequest request);
        public Task<UserResponse> RemoveUser(RemoveUserRequest request);
    }
}
