using _2dBurgerMobileApp.Domain.Entities.Models;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;

namespace _2dBurgerMobileApp.Services.DbServices
{
    public class ComboDbService
        (IBaseDbService baseDbService)
        : IComboDbService
    {
        private readonly string _baseEndpoint = "Combo/";
        public async Task<IEnumerable<Combo>> GetCombosAsync()
        {
            var response = await baseDbService.ListAsync<Combo>(_baseEndpoint + "GetCombos");
            if (response == null) { return Enumerable.Empty<Combo>(); }
            return response.Collection;
        }

        public async Task<IEnumerable<Combo>> GetCombosByCategoryIdAsync(int categoryId)
        {
            var response = await baseDbService.ListAsync<Combo>(_baseEndpoint + $"GetCombosByCategoryId/{categoryId}");
            if (response == null) { return Enumerable.Empty<Combo>(); }
            return response.Collection;
        }

        public async Task<Combo> GetComboById(int comboId)
        {
            var response = await baseDbService.FindAsync<Combo>(_baseEndpoint + $"GetComboById/{comboId}");
            if (response == null) { return default!; }
            return response.Data;
        }

    }
}
