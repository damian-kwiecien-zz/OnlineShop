using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities
{
    public class NewProduct
    {
        [Key, ForeignKey("Product")]
        public int Id { get; set; }

        virtual public Product Product { get; set; }
    }
}