using System.Collections.Generic;

namespace OnlineShop.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string Target { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> ImagesUrl { get; set; }

    }
}