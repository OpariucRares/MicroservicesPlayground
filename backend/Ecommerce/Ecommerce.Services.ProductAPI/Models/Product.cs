﻿namespace Ecommerce.Services.ProductAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}