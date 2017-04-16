using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DTOs
{
    public class ShoppingCartItemDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}