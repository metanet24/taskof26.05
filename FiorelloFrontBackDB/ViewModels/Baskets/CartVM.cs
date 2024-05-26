﻿namespace FiorelloFrontBackDB.ViewModels.Baskets
{
    public class CartVM
    {
        public int Id { get; set; }
        public string Image {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set;}
    }
}
