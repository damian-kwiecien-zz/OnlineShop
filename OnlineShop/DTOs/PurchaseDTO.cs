using System;
using System.Collections.Generic;

namespace OnlineShop.DTOs
{
    public class PurchaseDTO
    {
        public int Shipping { get; set; }

        public int ProductsCost { get; set; }

        public DateTime Date { get; set; }

        public PurchaserDataDTO PurchaserDataDTO { get; set; }

        public IEnumerable<ShoppingCartItemDTO> ShoppingCartItemDTOs { get; set; }
    }
}