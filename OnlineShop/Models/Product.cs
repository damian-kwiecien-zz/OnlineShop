namespace OnlineShop.Models
{
    public enum Target
    {
        He,
        She,
        Kids
    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string ImgUrl { get; set; }

        public string Type { get; set; }

        public Target Target { get; set; }
    }
}