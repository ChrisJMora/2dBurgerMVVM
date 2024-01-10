using _2dBurgerMobileApp.Domain.Entities.Models;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;

namespace _2dBurgerMobileApp.Services.DbServices
{
    public class UserDbService
        (IBaseDbService baseDbService)
        : IUserDbService
    {

        private readonly string _baseEndpoint = "User/";
        public async Task<User> LoginUserAsync(string username, string password)
        {
            var response = await baseDbService.FindAsync<User>(_baseEndpoint + $"login/{username}/{password}");
            if (response == null) { return default!; }
            return response.Data;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            var response = await baseDbService.AddAsync(_baseEndpoint + "register", user);
            if (response == null) { return default!; }
            return response.Data;
        }
    }
}
