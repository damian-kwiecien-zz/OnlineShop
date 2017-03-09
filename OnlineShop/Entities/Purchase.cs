using System;
using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        public int Shipping { get; set; }

        public DateTime Date { get; set; }

        public bool Pending { get; set; }

        virtual public PurchaserData PurchaserData { get; set; }

        virtual public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }

        public Purchase()
        {
            ShoppingCartItem = new List<ShoppingCartItem>();
        }
    }
}