namespace OnlineShop.DTOs
{
    public class PurchaserDataDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string AdditionalData { get; set; }

        public PurchaserDataDTO(string name, string surname, string phone, string email,
            string address, string city, string postCode, string country)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            Address = address;
            City = city;
            PostCode = postCode;
            Country = country;
        }
    }
}