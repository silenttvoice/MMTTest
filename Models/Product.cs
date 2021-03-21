using System;

namespace MMTTestApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SKU { get; set; }

        public decimal Price { get; set; }

    }
}
