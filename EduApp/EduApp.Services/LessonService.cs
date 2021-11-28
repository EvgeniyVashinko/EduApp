using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Lesson;
using EduApp.Core.Responses.Lesson;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _uow;

        public LessonService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<LessonResponse> GetLesson(GetLessonRequest request)
        {
            var lesson = await Task.Run(() => _uow.LessonRepository.Find(request.Id));
            if (lesson is null)
            {
                throw new AppException("Lesson with such id not found");
            }

            var response = new LessonResponse(lesson);

            return response;
        }

        public async Task<LessonListResponse> GetLessonList(LessonListRequest request)
        {
            var list = await Task.Run(() => _uow.LessonRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => x.Title.StartsWith(request.Title) && (request.CourseId == default || x.CourseId == request.CourseId)
            ));

            var response = new LessonListResponse(list);

            return response;
        }

        public async Task<LessonResponse> CreateLesson(CreateLessonRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            var lesson = new Lesson()
            {
                Title = request.Title,
                Description = request.Description,
                RecommendedTime = request.RecommendedTime,
                CreationDate = DateTime.Now,
                CourseId = request.CourseId,
            };

            _uow.LessonRepository.Add(lesson);

            _uow.Commit();

            var response = new LessonResponse(lesson);

            return response;
        }

        public async Task<LessonResponse> UpdateLesson(UpdateLessonRequest request)
        {
            var lesson = await Task.Run(() => _uow.LessonRepository.Find(request.Id));
            if (lesson is null)
            {
                throw new AppException("Lesson with such id not found", nameof(lesson));
            }

            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            lesson.Title = request.Title;
            lesson.Description = request.Description;
            lesson.RecommendedTime = request.RecommendedTime;
            lesson.UpdatedDate = DateTime.Now;
            lesson.CourseId = request.CourseId;

            _uow.LessonRepository.Update(lesson);

            _uow.Commit();

            var response = new LessonResponse(lesson);

            return response;
        }

        public async Task<LessonResponse> RemoveLesson(RemoveLessonRequest request)
        {
            var lesson = await Task.Run(() => _uow.LessonRepository.Find(request.Id));
            if (lesson is null)
            {
                throw new AppException("Lesson with such id not found");
            }

            _uow.LessonRepository.Remove(lesson);

            _uow.Commit();

            var response = new LessonResponse(lesson);

            return response;
        }
    }
}
