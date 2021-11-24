﻿using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.User;
using EduApp.Core.Responses;
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
            var user = await Task.Run(() => _uow.UserInfoRepository.Find(request.Id));

            var response = new UserResponse(user);

            return response;
        }

        public async Task<UserResponse> RemoveUser(RemoveUserRequest request)
        {
            var user = await Task.Run(() => _uow.UserInfoRepository.Find(request.Id));

            _uow.UserInfoRepository.Remove(user);

            _uow.Commit();

            var response = new UserResponse(user);

            return response;
        }

        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
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
                    Password = PasswordHelper.ComputeHash(request.Password),
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

            userInfo.FirstName = request.FirstName;
            userInfo.LastName = request.LastName;
            userInfo.Email = request.Email;
            userInfo.Account.Username = request.Username;
            userInfo.Account.Password = string.IsNullOrEmpty(request.Password) ? userInfo.Account.Password : PasswordHelper.ComputeHash(request.Password);
            userInfo.Birthday = request.Birthday;
            userInfo.Sex = request.Sex;
            userInfo.Image = request.Image ?? userInfo.Image;

            _uow.UserInfoRepository.Update(userInfo);

            _uow.Commit();

            var response = new UserResponse(userInfo);

            return response;
        }
    }
}