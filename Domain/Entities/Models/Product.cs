﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Entities.Models
{
    public class Product : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Product() { }
    }
}
