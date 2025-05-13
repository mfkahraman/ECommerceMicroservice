﻿namespace ECommerce.Catalog.DTOs.ProductDtos
{
    public class ResultProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
