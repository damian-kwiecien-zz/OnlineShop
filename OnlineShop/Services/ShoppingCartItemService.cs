using OnlineShop.DTOs;

namespace OnlineShop.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        public void SaveShoppingCartItem(ShoppingCartItemDTO dto)
        {
            new ProductService().GetProductBy(dto.ProductId);
        }
    }
}