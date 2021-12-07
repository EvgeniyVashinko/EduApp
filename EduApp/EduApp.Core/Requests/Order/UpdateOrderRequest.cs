using System;

namespace EduApp.Core.Requests.Order
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public decimal Sum { get; set; }
    }
}
