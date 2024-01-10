using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Entities.Models
{
    public class Combo : Product, IModel
    {
        public IEnumerable<Product> Foods { get; set; } = null!;

        public Combo() { }
    }
}
