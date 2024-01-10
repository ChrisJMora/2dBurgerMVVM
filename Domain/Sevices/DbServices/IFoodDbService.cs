using _2dBurgerMobileApp.Domain.Entities.Models;

namespace _2dBurgerMobileApp.Domain.Sevices.DbServices
{
    public interface IFoodDbService
    {
        Task<IEnumerable<Product>> GetFoodsAsync();
        Task<IEnumerable<Product>> GetFoodsByCategoryIdAsync(int categoryId);
        Task<Product> GetFoodByIdAsync(int foodId);
    }
}
