using _2dBurgerMobileApp.Domain.Entities.Models;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;

namespace _2dBurgerMobileApp.Services.DbServices
{
    public class FoodDbService
        (IBaseDbService baseDbService)
        : IFoodDbService
    {
        private readonly string _baseEndpoint = "Food/";
        public async Task<IEnumerable<Product>> GetFoodsAsync()
        {
            var response = await baseDbService.ListAsync<Product>(_baseEndpoint + "GetFoods");
            if (response == null) { return Enumerable.Empty<Product>(); }
            return response.Collection;
        }

        public async Task<IEnumerable<Product>> GetFoodsByCategoryIdAsync(int categoryId)
        {
            var response = await baseDbService.ListAsync<Product>(_baseEndpoint + $"GetFoodsByCategoryId/{categoryId}");
            if (response == null) { return Enumerable.Empty<Product>(); }
            return response.Collection;
        }
        public async Task<Product> GetFoodByIdAsync(int foodId)
        {
            var response = await baseDbService.FindAsync<Product>(_baseEndpoint + $"GetFoodById/{foodId}");
            if (response == null) { return default!; }
            return response.Data;
        }
    }
}