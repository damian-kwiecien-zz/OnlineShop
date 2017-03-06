using OnlineShop.Models;
using OnlineShop.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.PurchaseModels
{
    public class Purchase
    {
        public int Id { get; set; }

        public int Shipping { get; set; }

        public DateTime Date { get; set; }

        public bool Pending { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        virtual public ApplicationUser User { get; set; }

        virtual public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }

        public Purchase()
        {
            ShoppingCartItem = new List<ShoppingCartItem>();
        }
    }

    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }

        public string PurchaseId { get; set; }

        [ForeignKey("PurchaseId")]
        virtual public Purchase Purchase { get; set; }
    }
}