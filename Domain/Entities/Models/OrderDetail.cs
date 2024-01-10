using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Entities.Models
{
    public class OrderDetail : IModel
    {
        public int Id { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }

        public OrderDetail() { }
    }
}
