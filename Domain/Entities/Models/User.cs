
namespace _2dBurgerMobileApp.Domain.Entities.Models
{
    public class User : IModel
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string Username { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime LastAccessDate { get; set; }
    }
}
