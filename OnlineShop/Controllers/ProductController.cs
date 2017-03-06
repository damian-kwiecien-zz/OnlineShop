using OnlineShop.Models;
using OnlineShop.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnlineShop.Controllers
{
    public class ProductController : ApiController
    {

        private readonly OnlineShopDbContext _dbContext;

        public ProductController(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Products/Ids/?target=...&category=...&type
        [Route("api/products/ids")]
        [HttpGet]
        public IEnumerable<int> GetIds(string target, string category, string type)
        {
            var productsIds = _dbContext.Products.Where(p => (p.Target.ToString() == target) &&
            (p.Category == category) && (p.Type == type)).Select(p => p.Id).ToList();
            return productsIds;
        }

        // GET: api/Products/Ids/?searchParameter=...
        [Route("api/products/ids")]
        [HttpGet]
        public IEnumerable<int> GetIds(string searchParameter)
        {
            var productsIds = _dbContext.Products
                .Where(p => p.Name.ToLower().Contains(searchParameter.ToLower())).Select(p => p.Id).ToList();
            return productsIds;
        }

        // GET: api/Products/5
        public IEnumerable<Product> Get(int id)
        {
            var product = _dbContext.Products.Where(p => p.Id == id).ToList();
            return product;
        }

        // GET: api/Products/?ids=...    Example: api/Products/?ids=1,2,3
        public IEnumerable<Product> Get(string ids)
        {
            var idList = ids.Split(',').Select(el => int.Parse(el)).ToList();
            var products = _dbContext.Products.Where(p => idList.Contains(p.Id)).ToList();
            return products;
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

            var newProducts = _dbContext.Products.Where(p => idList.Contains(p.Id)).ToList();
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

            var bestProducts = _dbContext.Products.Where(p => idList.Contains(p.Id)).ToList();
            return bestProducts;
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
