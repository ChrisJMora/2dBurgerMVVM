using _2dBurgerMobileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Sevices.DbServices
{
    public interface ICategoryDbService
    {
        Task<IEnumerable<Category>> GetFoodCategoriesAsync();
        Task<IEnumerable<Category>> GetComboCategoriesAsync();
    }
}
