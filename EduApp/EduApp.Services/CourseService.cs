using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Course;
using EduApp.Core.Responses.Course;
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
                x => x.Title.StartsWith(request.Title) && (request.OwnerId == default || x.OwnerId == request.OwnerId)
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

            var list = new List<Category>();
            foreach (var categoryId in request.Categories ?? new())
            {
                var category = await Task.Run(() => _uow.CategoryRepository.Find(categoryId));
                if (category is null)
                {
                    throw new AppException("Category with such id not found", nameof(category));
                }

                list.Add(category);
            }

            var course = new Course()
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CreationDate = DateTime.Now,
                OwnerId = request.OwnerId,
                Categories = list
            };

            _uow.CourseRepository.Add(course);

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

            var list = new List<Category>();
            foreach (var categoryId in request.Categories ?? new())
            {
                var category = await Task.Run(() => _uow.CategoryRepository.Find(categoryId));
                if (category is null)
                {
                    throw new AppException("Category with such id not found", nameof(category));
                }

                list.Add(category);
            }

            course.Title = request.Title;
            course.Description = request.Description;
            course.Price = request.Price;
            course.UpdatedDate = DateTime.Now;
            course.OwnerId = request.OwnerId;
            course.Categories = list;

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
    }
}
