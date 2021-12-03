using System;

namespace EduApp.Core.Requests.Order
{
    public class CreateOrderRequest
    {
        public Guid AccountId { get; set; }
        public Guid CourseId { get; set; }
    }
}
