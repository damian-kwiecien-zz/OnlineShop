using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class Type
    {
        public int Id { get; set; }

        public string Name { get; set; }

        virtual public ICollection<Product> Product { get; set; }

        public Type()
        {
            Product = new List<Product>();
        }
    }
}