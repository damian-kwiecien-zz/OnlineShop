using OnlineShop.DTOs;
using OnlineShop.Extensions;
using OnlineShop.Models;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnlineShop.Controllers
{
    public class ProductController : ApiController
    {

        private readonly OnlineShopDbContext _dbContext;
        private readonly IProductService _productService;

        public ProductController(OnlineShopDbContext dbContext, IProductService productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }

        // GET: api/Products/Ids/?target=...&category=...&type
        [Route("api/products/ids")]
        [HttpGet]
        public IEnumerable<int> GetIds(string target, string category, string type)
        {
            return _productService.GetProductsIdsBy(target, category, type);
        }

        // GET: api/Products/Ids/?searchParameter=...
        [Route("api/products/ids")]
        [HttpGet]
        public IEnumerable<int> GetIds(string searchParameter)
        {
            return _productService.GetProductsIdsBy(searchParameter);
        }

        // GET: api/Products/5
        public ProductDTO Get(int id)
        {
            return _productService.GetProductBy(id);
        }

        // GET: api/Products/?ids=...    Example: api/Products/?ids=1,2,3
        public IEnumerable<ProductDTO> Get(string ids)
        {
            var idList = ids.Split(',').Select(el => int.Parse(el)).ToList();
            return _productService.GetProductsBy(idList);
        }

        [Route("api/products/new")]
        [HttpGet]
        public IEnumerable<ProductDTO> GetNew()
        {
            var ids = _dbContext.NewProducts.Select(p => p.Id).ToList();
            ids.Shuffle();
            ids.Take(3);
            return _productService.GetProductsBy(ids);
        }

        [Route("api/products/best")]
        [HttpGet]
        public IEnumerable<ProductDTO> GetBest()
        {
            Random rnd = new Random();
            var ids = _dbContext.BestProducts.Select(p => p.Id).ToList();
            ids.Shuffle();
            ids.Take(3);
            return _productService.GetProductsBy(ids);
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
