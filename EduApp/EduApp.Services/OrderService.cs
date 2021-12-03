using EduApp.Core.Entities;
using EduApp.Core.Helpers;
using EduApp.Core.Pagination;
using EduApp.Core.Repositories;
using EduApp.Core.Requests.Order;
using EduApp.Core.Responses.Order;
using EduApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OrderResponse> GetOrder(GetOrderRequest request)
        {
            var order = await Task.Run(() => _uow.OrderRepository.Find(request.Id));
            if (order is null)
            {
                throw new AppException("Order with such id not found");
            }

            var response = new OrderResponse(order);

            return response;
        }

        public async Task<OrderListResponse> GetOrderList(OrderListRequest request)
        {
            var list = await Task.Run(() => _uow.OrderRepository.GetPagedList
            (
                new PageInfo(request.Page, request.PageSize),
                x => (request.AccountId == default || x.AccountId == request.AccountId) &&
                        (request.CourseId == default || x.CourseId == request.CourseId)
            ));

            var response = new OrderListResponse(list);

            return response;
        }

        public async Task<OrderResponse> CreateOrder(CreateOrderRequest request)
        {
            var course = await Task.Run(() => _uow.CourseRepository.Find(request.CourseId));
            if (course is null)
            {
                throw new AppException("Course with such id not found", nameof(course));
            }

            var account = await Task.Run(() => _uow.AccountRepository.Find(request.AccountId));
            if (account is null)
            {
                throw new AppException("Account with such id not found", nameof(account));
            }

            var order = new Order()
            {
                AccountId = request.AccountId,
                CourseId = request.CourseId,
                CreationDate = DateTime.Now,
                Sum = course.Price,
            };

            _uow.OrderRepository.Add(order);

            _uow.Commit();

            var response = new OrderResponse(order);

            return response;
        }

        public async Task<OrderResponse> UpdateOrder(UpdateOrderRequest request)
        {
            var order = await Task.Run(() => _uow.OrderRepository.Find(request.Id));
            if (order is null)
            {
                throw new AppException("Order with such id not found", nameof(order));
            }

            order.Sum = request.Sum;

            _uow.OrderRepository.Update(order);

            _uow.Commit();

            var response = new OrderResponse(order);

            return response;
        }

        public async Task<OrderResponse> RemoveOrder(RemoveOrderRequest request)
        {
            var order = await Task.Run(() => _uow.OrderRepository.Find(request.Id));
            if (order is null)
            {
                throw new AppException("Order with such id not found");
            }

            _uow.OrderRepository.Remove(order);

            _uow.Commit();

            var response = new OrderResponse(order);

            return response;
        }
    }
}
