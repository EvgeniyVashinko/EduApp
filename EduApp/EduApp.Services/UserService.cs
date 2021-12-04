using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.User;
using EduApp.Core.Responses.User;
using EduApp.Core.Services;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserResponse> GetUser(GetUserRequest request)
        {
            var user = await Task.Run(() => _uow.UserInfoRepository.Find(x => x.AccountId == request.Id));
            if (user is null)
            {
                throw new AppException("User not found");
            }

            var response = new UserResponse(user);

            return response;
        }

        public async Task<UserListResponse> GetUserList(UserListRequest request)
        {
            var list = await Task.Run(() => _uow.UserInfoRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => x.FirstName.StartsWith(request.FirstName) &&
                    x.LastName.StartsWith(request.LastName) &&
                    x.Email.StartsWith(request.Email) &&
                    x.Account.Username.StartsWith(request.UserName)
            ));

            var response = new UserListResponse(list);

            return response;
        }

        public async Task<UserResponse> RemoveUser(RemoveUserRequest request)
        {
            var user = await Task.Run(() => _uow.UserInfoRepository.Find(request.Id));
            if (user is null)
            {
                throw new AppException("User not found");
            }

            _uow.UserInfoRepository.Remove(user);

            _uow.Commit();

            var response = new UserResponse(user);

            return response;
        }

        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new AppException("Username is required");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new AppException("Password is required");
            }

            var user = await Task.Run(() => _uow.AccountRepository.FindByUsername(request.Username));
            if (user is not null)
            {
                throw new AppException($"Username \"{user.Username}\" is already taken");
            }

            var salt = PasswordHelper.GenerateSalt(Account.PasswordSaltLength);
            var userInfo = new UserInfo
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Birthday = request.Birthday,
                Image = request.Image,
                Sex = request.Sex,
                Account = new Account
                {
                    Username = request.Username,
                    PasswordSalt = salt,
                    Password = PasswordHelper.ComputeHash(request.Password, salt)
                }
            };

            _uow.UserInfoRepository.Add(userInfo);

            //var role = _uow.RoleRepository.Find(new Guid("C5EF356C-59A6-EA11-B894-34415DD8A3D2"));
            //userInfo.Account.Roles = new List<Role>
            //{
            //    role
            //};

            _uow.Commit();

            var response = new UserResponse(userInfo);

            return response;
        }

        public async Task<UserResponse> UpdateUser(UpdateUserRequest request)
        {
            var userInfo = await Task.Run(() => _uow.UserInfoRepository.Find(request.Id));
            if (userInfo is null)
            {
                throw new AppException("User not found");
            }

            userInfo.FirstName = request.FirstName;
            userInfo.LastName = request.LastName;
            userInfo.Email = request.Email;
            userInfo.Account.Username = request.Username;
            userInfo.Birthday = request.Birthday;
            userInfo.Sex = request.Sex;
            userInfo.Image = request.Image ?? userInfo.Image;

            if (!string.IsNullOrEmpty(request.Password))
            {
                userInfo.Account.ChangePassword(request.Password);
            }

            _uow.UserInfoRepository.Update(userInfo);

            _uow.Commit();

            var response = new UserResponse(userInfo);

            return response;
        }
    }
}
