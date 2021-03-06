using EduApp.Core.Entities;
using EduApp.Core.Extensions;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Course;
using EduApp.Core.Responses.Course;
using EduApp.Core.Responses.User;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;

        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CourseResponse> GetCourse(GetCourseRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.Id));
            if (course is null)
            {
                throw new AppException("Course with such id not found");
            }

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<CourseListResponse> GetCourseList(CourseListRequest request)
        {
            var list = await Task.Run(() => _uow.CourseRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => x.Title.StartsWith(request.Title) && 
                    (request.OwnerId == default || x.OwnerId == request.OwnerId) &&
                    (request.ParticipantId == default || x.Participants.Any(x => x.Id == request.ParticipantId)) &&
                    (request.IsActive == null || x.IsActive == request.IsActive)
            ));

            var response = new CourseListResponse(list);

            return response;
        }

        public async Task<CourseResponse> CreateCourse(CreateCourseRequest request)
        {
            var account = await Task.Run(() => _uow.AccountRepository.Find(request.OwnerId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var course = new Course()
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CreationDate = DateTime.Now,
                OwnerId = request.OwnerId,
                Categories = new List<Category>()
            };

            _uow.CourseRepository.Add(course);

            foreach (var categoryId in request.Categories ?? new())
            {
                var category = await Task.Run(() => _uow.CategoryRepository.Find(categoryId));
                if (category is null)
                {
                    throw new AppException("Category with such id not found", nameof(category));
                }

                course.Categories.Add(category);
            }

            _uow.Commit();

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<CourseResponse> UpdateCourse(UpdateCourseRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.Id));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            var account = await Task.Run(() => _uow.AccountRepository.Find(request.OwnerId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            course.Title = request.Title;
            course.Description = request.Description;
            course.Price = request.Price;
            course.UpdatedDate = DateTime.Now;
            course.OwnerId = request.OwnerId;
            course.Categories ??= new List<Category>();

            foreach (var categoryId in request.Categories ?? new())
            {
                var category = await Task.Run(() => _uow.CategoryRepository.Find(categoryId));
                if (category is null)
                {
                    throw new AppException("Category with such id not found", nameof(category));
                }

                course.Categories.Add(category);
            }

            _uow.CourseRepository.Update(course);

            _uow.Commit();

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<CourseResponse> RemoveCourse(RemoveCourseRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.Id));
            if (course is null)
            {
                throw new AppException("Course with such id not found");
            }

            _uow.CourseRepository.Remove(course);

            _uow.Commit();

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<CourseResponse> AddParticipant(ParticipantRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            var courseOwnerUserInfo = await Task.Run(() => _uow.UserInfoRepository.Find(x => x.AccountId == course.OwnerId));

            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var userInfo = await Task.Run(() => _uow.UserInfoRepository.Find(x => x.AccountId == request.AccountId));
            if(userInfo.AccountAmmount < course.Price)
            {
                throw new AppException("You don't have enough money", nameof(account));
            }

            if (!course.Participants.Contains(account))
            {
                course.Participants.Add(account);
                userInfo.AccountAmmount -= course.Price;
                courseOwnerUserInfo.AccountAmmount += course.Price * 0.9M;

                _uow.Commit();
            }

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<CourseResponse> RemoveParticipant(ParticipantRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            if (course.Participants.Contains(account))
            {
                course.Participants.Remove(account);

                _uow.Commit();
            }

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<UserListResponse> GetCourseParticipantList(ParticipantListRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            
            var query = course.Participants.AsQueryable();
            var pageInfo = new PageInfo(request.Page, request.PageSize);
            var pageItems = query.SelectPage(pageInfo).Select(x => x.UserInfo).ToList();

            var pl = new PagedList<UserInfo>(pageItems, query.Count(), pageInfo);

            return new UserListResponse(pl);
        }

        public async Task<CourseResponse> ApproveCourse(GetCourseRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.Id));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            course.IsActive = true;

            _uow.CourseRepository.Update(course);

            _uow.Commit();

            var response = new CourseResponse(course);

            return response;
        }

        public async Task<CourseResponse> DeclineCourse(GetCourseRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.Id));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            course.IsActive = false;

            _uow.CourseRepository.Update(course);

            _uow.Commit();

            var response = new CourseResponse(course);

            return response;
        }
    }
}
