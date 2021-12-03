using EduApp.Core.Requests.Order;
using EduApp.Core.Responses.Order;
using System.Threading.Tasks;

namespace EduApp.Core.Services
{
    public interface IOrderService
    {
        public Task<OrderResponse> GetOrder(GetOrderRequest request);
        public Task<OrderListResponse> GetOrderList(OrderListRequest request);
        public Task<OrderResponse> CreateOrder(CreateOrderRequest request);
        public Task<OrderResponse> UpdateOrder(UpdateOrderRequest request);
        public Task<OrderResponse> RemoveOrder(RemoveOrderRequest request);
    }
}
