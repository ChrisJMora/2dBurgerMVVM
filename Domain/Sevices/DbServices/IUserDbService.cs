using _2dBurgerMobileApp.Domain.Entities.Models;

namespace _2dBurgerMobileApp.Domain.Sevices.DbServices
{
    public interface IUserDbService
    {
        Task<User> LoginUserAsync(string username, string password);
        Task<User> RegisterUserAsync(User user);
    }
}
