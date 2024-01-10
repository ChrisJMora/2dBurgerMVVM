using _2dBurgerMobileApp.Domain.Entities.Models;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;

namespace _2dBurgerMobileApp.Services.DbServices
{
    public class CategoryDbService
        (IBaseDbService baseDbService)
        : ICategoryDbService
    {
        private readonly string _baseEndpoint = "Category/";
        public async Task<IEnumerable<Category>> GetFoodCategoriesAsync()
        {
            var response = await baseDbService.ListAsync<Category>(_baseEndpoint + "GetFoodCategories");
            if (response == null) { return Enumerable.Empty<Category>(); }
            return response.Collection;
        }

        public async Task<IEnumerable<Category>> GetComboCategoriesAsync()
        {
            var response = await baseDbService.ListAsync<Category>(_baseEndpoint + "GetComboCategories");
            if (response == null) { return Enumerable.Empty<Category>(); }
            return response.Collection;
        }
    }
}