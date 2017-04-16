using OnlineShop.DTOs;
using OnlineShop.Extensions;
using OnlineShop.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnlineShop.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products/Ids/?target=...&category=...&type
        [Route("api/product/ids")]
        [HttpGet]
        public IEnumerable<int> GetIds(string target, string category, string type)
        {
            return _productService.GetProductsIdsBy(target, category, type);
        }

        // GET: api/Products/Ids/?searchParameter=...
        [Route("api/product/ids")]
        [HttpGet]
        public IEnumerable<int> GetIds(string searchParameter)
        {
            return _productService.GetProductsIdsBy(searchParameter);
        }

        // GET: api/product/5
        public ProductDTO Get(int id)
        {
            return _productService.GetProductBy(id);
        }

        // GET: api/product/?ids=...    Example: api/Products/?ids=1,2,3
        public IEnumerable<ProductDTO> Get(string ids)
        {
            var idList = ids.Split(',').Select(el => int.Parse(el)).ToList();
            return _productService.GetProductsBy(idList);
        }

        [Route("api/product/new")]
        [HttpGet]
        public IEnumerable<ProductDTO> GetNew()
        {
            var ids = _productService.GetProductsIds() as List<int>;
            ids.Shuffle();
            var ids2 = ids.Take(3);
            return _productService.GetProductsBy(ids2);
        }

        [Route("api/product/best")]
        [HttpGet]
        public IEnumerable<ProductDTO> GetBest()
        {

            var ids = _productService.GetProductsIds() as List<int>;
            ids.Shuffle();
            var ids2 = ids.Take(3);
            return _productService.GetProductsBy(ids2);
        }



    }
}
