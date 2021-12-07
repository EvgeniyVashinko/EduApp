using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Homework;
using EduApp.Core.Responses.Homework;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IUnitOfWork _uow;

        public HomeworkService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<HomeworkResponse> GetHomework(GetHomeworkRequest request)
        {
            var homework = await Task.Run(() => _uow.HomeworkRepository.Find(request.Id));
            if (homework is null)
            {
                throw new AppException("Homework with such id not found");
            }

            var response = new HomeworkResponse(homework);

            return response;
        }

        public async Task<HomeworkListResponse> GetHomeworkList(HomeworkListRequest request)
        {
            var list = await Task.Run(() => _uow.HomeworkRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => (request.AccountId == default || x.AccountId == request.AccountId) &&
                        (request.LessonId == default || x.LessonId == request.LessonId) &&
                        (request.CourseId == default || x.Lesson.CourseId == request.CourseId) &&
                        (!request.IsTableRequest || (request.IsTableRequest && x.Mark == default))
            ));

            var response = new HomeworkListResponse(list);

            return response;
        }

        public async Task<HomeworkResponse> CreateHomework(CreateHomeworkRequest request)
        {
            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var lesson = await Task.Run(() => _uow.LessonRepository.Find(request.LessonId));
            if (lesson is null)
            {
                throw new AppException("Lesson with such id not found", nameof(lesson));
            }

            if (request.Mark < 0 || request.Mark > 10)
            {
                throw new AppException("Mark must be between 0 and 10", nameof(request.Mark));
            }

            var homework = new Homework()
            {
                AccountId = request.AccountId,
                LessonId = request.LessonId,
                Answer = request.Answer,
                Url = request.Url,
                Mark = request.Mark
            };

            _uow.HomeworkRepository.Add(homework);

            _uow.Commit();

            var response = new HomeworkResponse(homework);

            return response;
        }

        public async Task<HomeworkResponse> UpdateHomework(UpdateHomeworkRequest request)
        {
            var homework = await Task.Run(() => _uow.HomeworkRepository.Find(request.Id));
            if (homework is null)
            {
                throw new AppException("Homework with such id not found", nameof(homework));
            }

            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var lesson = await Task.Run(() => _uow.LessonRepository.Find(request.LessonId));
            if (lesson is null)
            {
                throw new AppException("Lesson with such id not found", nameof(lesson));
            }

            if (request.Mark < 0 || request.Mark > 10)
            {
                throw new AppException("Mark must be between 0 and 10", nameof(request.Mark));
            }

            homework.AccountId = request.AccountId;
            homework.LessonId = request.LessonId;
            homework.Answer = request.Answer;
            homework.Url = request.Url;
            homework.Mark = request.Mark;

            _uow.HomeworkRepository.Update(homework);

            _uow.Commit();

            var response = new HomeworkResponse(homework);

            return response;
        }

        public async Task<HomeworkResponse> RemoveHomework(RemoveHomeworkRequest request)
        {
            var homework = await Task.Run(() => _uow.HomeworkRepository.Find(request.Id));
            if (homework is null)
            {
                throw new AppException("Homework with such id not found", nameof(homework));
            }

            _uow.HomeworkRepository.Remove(homework);

            _uow.Commit();

            var response = new HomeworkResponse(homework);

            return response;
        }
    }
}
