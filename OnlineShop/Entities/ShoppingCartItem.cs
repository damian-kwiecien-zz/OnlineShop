using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }

        public int PurchaseId { get; set; }

        [ForeignKey("PurchaseId")]
        virtual public Purchase Purchase { get; set; }
    }
}