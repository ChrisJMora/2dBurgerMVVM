using _2dBurgerMobileApp.Domain.Entities.Models;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;

namespace _2dBurgerMobileApp.Services.DbServices
{
    public class OrderDbService
        (IBaseDbService baseDbService)
        : IOrderDbServices
    {
        private readonly string _baseEndpoint = "Order/";
        public async Task<IEnumerable<Order>> GetOrdersAsync(int customerId)
        {
            var response = await baseDbService.ListAsync<Order>(_baseEndpoint + $"GetOrders/{customerId}");
            if (response == null) { return Enumerable.Empty<Order>(); }
            return response.Collection;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var response = await baseDbService.FindAsync<Order>(_baseEndpoint + $"GetOrderById/{orderId}");
            if (response == null) { return default!; }
            return response.Data;
        }
        public async Task<Order> AddOrderAsync(Order newOrder)
        {
            var response = await baseDbService.AddAsync(_baseEndpoint + "AddOrder", newOrder);
            if (response == null) { return default!; }
            return response.Data;
        }
    }
}