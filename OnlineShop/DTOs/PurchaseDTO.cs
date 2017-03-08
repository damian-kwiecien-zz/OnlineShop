using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DTOs
{
    public class PurchaseDTO
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
}