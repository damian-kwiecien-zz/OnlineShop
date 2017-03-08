using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        virtual public Product Product { get; set; }
    }
}