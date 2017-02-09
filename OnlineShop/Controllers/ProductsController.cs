using OnlineShop.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq.Expressions;
using System.Linq;

namespace OnlineShop.Controllers
{
    public class ProductsController : ApiController
    {

        readonly OnlineShopDbContext _dbContext;

        public ProductsController(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Products
        public IEnumerable<string> Get(string target, string type)
        {
            _dbContext.Products.Where(p => (p.Target.ToString() == target) && (p.Type == type));
            return new string[] { target, type };
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
