using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities
{
    public class PurchaserData
    {
        [Key, ForeignKey("Purchase")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string AdditionalData { get; set; }

        virtual public Purchase Purchase { get; set; }
    }
}