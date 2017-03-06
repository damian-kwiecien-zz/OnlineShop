using OnlineShop.ProductModels;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnlineShop.Models
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<NewProduct> NewProducts { get; set; }
        public DbSet<BestProduct> BestProducts { get; set; }

        public OnlineShopDbContext() : base("OnlineShopConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}