using OnlineShop.DTOs;
using System.Collections.Generic;

namespace OnlineShop.Services
{
    public interface IProductService
    {
        ProductDTO GetProductBy(int id);

        IEnumerable<ProductDTO> GetProductsBy(IEnumerable<int> ids);

        IEnumerable<int> GetProductsIds();

        IEnumerable<int> GetProductsIdsBy(string target, string category, string type);

        IEnumerable<int> GetProductsIdsBy(string searchParameter);
    }
}
