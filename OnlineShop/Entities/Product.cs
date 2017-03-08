using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public int TargetId { get; set; }

        [ForeignKey("TargetId")]
        virtual public Target Target { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        virtual public Category Category { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        virtual public Type Type { get; set; }

        virtual public ICollection<Image> Image { get; set; }

        virtual public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }

        virtual public NewProduct NewProduct { get; set; }

        virtual public BestProduct BestProduct { get; set; }

        public Product()
        {
            Image = new List<Image>();
            ShoppingCartItem = new List<ShoppingCartItem>();
        }

    }
}