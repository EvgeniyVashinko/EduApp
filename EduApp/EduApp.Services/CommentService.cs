using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Comment;
using EduApp.Core.Responses.Comment;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;

        public CommentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CommentResponse> GetComment(GetCommentRequest request)
        {
            var comment = await Task.Run(() => _uow.CommentRepository.Find(request.Id));
            if (comment is null)
            {
                throw new AppException("Review with such id not found");
            }

            var response = new CommentResponse(comment);

            return response;
        }

        public async Task<CommentListResponse> GetCommentList(CommentListRequest request)
        {
            var list = await Task.Run(() => _uow.CommentRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => (request.AccountId == default || x.AccountId == request.AccountId) &&
                        (request.LessonId == default || x.LessonId == request.LessonId)
            ));

            var response = new CommentListResponse(list);

            return response;
        }

        public async Task<CommentResponse> CreateComment(CreateCommentRequest request)
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

            if (string.IsNullOrEmpty(request.Text))
            {
                throw new AppException("Text cannot be null", nameof(request.Text));
            }

            var comment = new Comment()
            {
                AccountId = request.AccountId,
                LessonId = request.LessonId,
                Text = request.Text,
                CreationDate = DateTime.Now,
            };

            _uow.CommentRepository.Add(comment);

            _uow.Commit();

            var response = new CommentResponse(comment);

            return response;
        }

        public async Task<CommentResponse> UpdateComment(UpdateCommentRequest request)
        {
            var comment = await Task.Run(() => _uow.CommentRepository.Find(request.Id));
            if (comment is null)
            {
                throw new AppException("Comment with such id not found", nameof(comment));
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

            if (string.IsNullOrEmpty(request.Text))
            {
                throw new AppException("Text cannot be null", nameof(request.Text));
            }

            comment.AccountId = request.AccountId;
            comment.LessonId = request.LessonId;
            comment.Text = request.Text;
            comment.UpdatedDate = DateTime.Now;

            _uow.CommentRepository.Update(comment);

            _uow.Commit();

            var response = new CommentResponse(comment);

            return response;
        }

        public async Task<CommentResponse> RemoveComment(RemoveCommentRequest request)
        {
            var comment = await Task.Run(() => _uow.CommentRepository.Find(request.Id));
            if (comment is null)
            {
                throw new AppException("Comment with such id not found", nameof(comment));
            }

            _uow.CommentRepository.Remove(comment);

            _uow.Commit();

            var response = new CommentResponse(comment);

            return response;
        }
    }
}
