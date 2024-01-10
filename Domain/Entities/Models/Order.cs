using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Entities.Models
{
    public class Order : IModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; } = null!;
        public Customer Customer { get; set; } = null!;

        public Order() { }
    }
}
