
using _2dBurgerMobileApp.Domain.Entities.Models;

namespace _2dBurgerMobileApp.Domain.Sevices.DbServices
{
    public interface IOrderDbServices
    {
        Task<IEnumerable<Order>> GetOrdersAsync(int customerId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> AddOrderAsync(Order newOrder);
    }
}