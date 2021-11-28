using System;

namespace EduApp.Core.Responses.Review
{
    public class ReviewResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ReviewResponse()
        {
        }

        public ReviewResponse(Entities.Review review)
        {
            Id = review.Id;
            AccountId = review.AccountId;
            CourseId = review.CourseId;
            Value = review.Value;
            Description = review.Description;
            CreationDate = review.CreationDate;
            UpdatedDate = review.UpdatedDate;
        }
    }
}
