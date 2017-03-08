using AutoMapper;
using OnlineShop.DTOs;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services
{
    public class ProductService : IProductService
    {
        private readonly OnlineShopDbContext _dbContext;

        public ProductService(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductDTO GetProductBy(int id)
        {
            var product = _dbContext.Products.Where(p => p.Id == id).ToList().First();
            return Mapper.Map<ProductDTO>(product);

        }

        public IEnumerable<ProductDTO> GetProductsBy(IEnumerable<int> ids)
        {
            var products = _dbContext.Products.Where(p => ids.Contains(p.Id)).ToList();
            return Mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public IEnumerable<int> GetProductsIds()
        {
            return _dbContext.Products.Select(p => p.Id).ToList();
        }

        public IEnumerable<int> GetProductsIdsBy(string searchParameter)
        {
            var productsIds = _dbContext.Products
                .Where(p => p.Name.ToLower().Contains(searchParameter.ToLower())).Select(p => p.Id).ToList();
            return productsIds;
        }

        public IEnumerable<int> GetProductsIdsBy(string target, string category, string type)
        {
            var productsIds = _dbContext.Products.Where(p => (p.Target.ToString() == target) &&
            (p.Category.Name == category) && (p.Type.Name == type)).Select(p => p.Id).ToList();
            return productsIds;
        }
    }
}