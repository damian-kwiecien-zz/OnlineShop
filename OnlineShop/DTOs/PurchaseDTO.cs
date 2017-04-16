using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DTOs
{
    public class PurchaseDTO
    {
        [Required]
        public int Shipping { get; set; }

        [Required]
        public int ProductsCost { get; set; }

        [Required]
        public PurchaserDataDTO PurchaserDataDTO { get; set; }

        [Required]
        public IEnumerable<ShoppingCartItemDTO> ShoppingCartItemDTOs { get; set; }
    }
}