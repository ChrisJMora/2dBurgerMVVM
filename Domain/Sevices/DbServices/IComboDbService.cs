using _2dBurgerMobileApp.Domain.Entities.Models;

namespace _2dBurgerMobileApp.Domain.Sevices.DbServices
{
    public interface IComboDbService
    {
        Task<IEnumerable<Combo>> GetCombosAsync();
        Task<IEnumerable<Combo>> GetCombosByCategoryIdAsync(int categoryId);
        Task<Combo> GetComboById(int comboId);
    }
}