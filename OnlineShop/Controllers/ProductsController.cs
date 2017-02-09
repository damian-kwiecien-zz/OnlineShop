using OnlineShop.Models;
using System.Collections.Generic;
using System.Web.Http;


namespace OnlineShop.Controllers
{
    public class ProductsController : ApiController
    {

        readonly OnlineShopDbContext _dbContext;

        public ProductsController(OnlineShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        // GET: api/Products
        public IEnumerable<string> Get()
        {

            Product p = new Product()
            {
                Name = "Name",
                Description = "Nope",
                Details = "nope",
                ImgUrl = "/",
                Price = 0,
                Target = Target.He,
                Type = "Clothes"
            };
            _dbContext.Products.Add(p);
            _dbContext.SaveChanges();
            return new string[] { "value1", "value2", _dbContext.Products.ToString() };
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
