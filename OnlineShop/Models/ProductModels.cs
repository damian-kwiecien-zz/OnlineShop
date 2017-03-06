using OnlineShop.PurchaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.ProductModels
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
        virtual public string Category { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        virtual public string Type { get; set; }

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

    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }
    }

    public class NewProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }
    }

    public class BestProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }

    }

}