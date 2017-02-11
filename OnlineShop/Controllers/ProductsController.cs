using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnlineShop.Controllers
{
    public class ProductsController : ApiController
    {

        private readonly OnlineShopDbContext _dbContext;

        public ProductsController(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/Products
        public IEnumerable<int> Get(string target, string category, string type)
        {
            var productsIdList = _dbContext.Products.Where(p => (p.Target.ToString() == target) &&
            (p.Category == category) && (p.Type == type)).Select(p => p.Id);
            return productsIdList;
        }

        [Route("api/products/new")]
        [HttpGet]
        public IEnumerable<Product> GetNew()
        {
            Random rnd = new Random();
            var lastId = _dbContext.NewProducts.OrderByDescending(p => p.Id).First().Id;
            var idList = new List<int>();
            int id;

            while (idList.Count != 3)
            {
                id = rnd.Next(1, (lastId + 1)); // [a,b)

                if (idList.Contains(id))
                    continue;
                else
                    idList.Add(id);
            }

            var newProducts = _dbContext.Products.Where(p => idList.Contains(p.Id));
            return newProducts;
        }



        [Route("api/products/best")]
        [HttpGet]
        public IEnumerable<Product> GetBest()
        {
            Random rnd = new Random();
            var lastId = _dbContext.BestProducts.OrderByDescending(p => p.Id).First().Id;
            var idList = new List<int>();
            int id;

            while (idList.Count != 3)
            {
                id = rnd.Next(1, (lastId + 1)); // [a,b)

                if (idList.Contains(id))
                    continue;
                else
                    idList.Add(id);
            }

            var bestProducts = _dbContext.Products.Where(p => idList.Contains(p.Id));
            return bestProducts;
        }

        // GET: api/Products/5
        public IEnumerable<Product> Get(int id)
        {
            var product = _dbContext.Products.Where(p => p.Id == id);
            return product;

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
