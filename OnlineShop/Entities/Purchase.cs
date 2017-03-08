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

        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //virtual public ApplicationUser User { get; set; }

        virtual public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }

        public Purchase()
        {
            ShoppingCartItem = new List<ShoppingCartItem>();
        }
    }
}