using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        virtual public ICollection<Product> Product { get; set; }

        public Category()
        {
            Product = new List<Product>();
        }
    }
}