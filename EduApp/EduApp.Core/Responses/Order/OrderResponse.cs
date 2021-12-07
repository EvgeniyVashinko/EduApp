using System;

namespace EduApp.Core.Responses.Order
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Sum { get; set; }

        public OrderResponse()
        {
        }

        public OrderResponse(Entities.Order order)
        {
            Id = order.Id;
            CourseId = order.CourseId;
            AccountId = order.AccountId;
            CreationDate = order.CreationDate;
            Sum = order.Sum;
        }
    }
}
