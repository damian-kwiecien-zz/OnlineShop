using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.PurchaseModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        virtual public ICollection<Purchase> Purchase { get; set; }

        public ApplicationUser()
        {
            Purchase = new List<Purchase>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("OnlineShopConnection", throwIfV1Schema: false)
        {

            var roleStore = new RoleStore<IdentityRole>(this);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = "admin" });
            roleManager.Create(new IdentityRole { Name = "customer" });

            var userStore = new UserStore<ApplicationUser>(this);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
            userManager.Create(user);
            userManager.AddToRole(user.Id, "admin");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}