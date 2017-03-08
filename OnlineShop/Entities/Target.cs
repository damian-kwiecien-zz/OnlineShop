using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class Target
    {
        public int Id { get; set; }

        public string Name { get; set; }

        virtual public ICollection<Product> Product { get; set; }

        public Target()
        {
            Product = new List<Product>();
        }
    }
}