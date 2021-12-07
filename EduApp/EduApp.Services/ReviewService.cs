using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Review;
using EduApp.Core.Responses.Review;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _uow;

        public ReviewService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ReviewResponse> GetReview(GetReviewRequest request)
        {
            var review = await Task.Run(() => _uow.ReviewRepository.Find(request.Id));
            if (review is null)
            {
                throw new AppException("Review with such id not found");
            }

            var response = new ReviewResponse(review);

            return response;
        }

        public async Task<ReviewListResponse> GetReviewList(ReviewListRequest request)
        {
            var list = await Task.Run(() => _uow.ReviewRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => (request.AccountId == default || x.AccountId == request.AccountId) &&
                        (request.CourseId == default || x.CourseId == request.CourseId)
            ));

            var response = new ReviewListResponse(list);

            return response;
        }

        public async Task<ReviewResponse> CreateReview(CreateReviewRequest request)
        {
            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            if (request.Value < 0 || request.Value > 5)
            {
                throw new AppException("Value must be between 0 and 5", nameof(request.Value));
            }

            var review = new Review()
            {
                AccountId = request.AccountId,
                CourseId = request.CourseId,
                Value = request.Value,
                Description = request.Description,
                CreationDate = DateTime.Now,
            };

            _uow.ReviewRepository.Add(review);

            _uow.Commit();

            var response = new ReviewResponse(review);

            return response;
        }

        public async Task<ReviewResponse> UpdateReview(UpdateReviewRequest request)
        {
            var review = await Task.Run(() => _uow.ReviewRepository.Find(request.Id));
            if (review is null)
            {
                throw new AppException("Review with such id not found", nameof(review));
            }

            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            if (request.Value < 0 || request.Value > 5)
            {
                throw new AppException("Value must be between 0 and 5", nameof(request.Value));
            }

            review.AccountId = request.AccountId;
            review.CourseId = request.CourseId;
            review.Description = request.Description;
            review.Value = request.Value;
            review.UpdatedDate = DateTime.Now;

            _uow.ReviewRepository.Update(review);

            _uow.Commit();

            var response = new ReviewResponse(review);

            return response;
        }

        public async Task<ReviewResponse> RemoveReview(RemoveReviewRequest request)
        {
            var review = await Task.Run(() => _uow.ReviewRepository.Find(request.Id));
            if (review is null)
            {
                throw new AppException("Review with such id not found", nameof(review));
            }

            _uow.ReviewRepository.Remove(review);

            _uow.Commit();

            var response = new ReviewResponse(review);

            return response;
        }
    }
}
