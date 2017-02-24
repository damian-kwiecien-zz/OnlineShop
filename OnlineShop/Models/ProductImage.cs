using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }
    }
}