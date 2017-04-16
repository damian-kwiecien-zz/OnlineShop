using AutoMapper;
using OnlineShop.DTOs;
using OnlineShop.Entities;
using OnlineShop.Models;
using System;
using System.Linq;

namespace OnlineShop.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly OnlineShopDbContext _dbContext;
        private readonly ProductService _productService;

        public PurchaseService(OnlineShopDbContext dbContext, ProductService productService)
        {
            _dbContext = dbContext;
        }

        public void AddPurchase(PurchaseDTO dto)
        {

            Validate(dto);

            var purchase = Mapper.Map<PurchaseDTO, Purchase>(dto);
            purchase.Pending = true;
            purchase.Date = DateTime.Now;

            foreach (var el in dto.ShoppingCartItemDTOs)
            {
                var cartItem = Mapper.Map<ShoppingCartItemDTO, ShoppingCartItem>(el);
                cartItem.Product = _dbContext.Products.Where(p => p.Id == el.ProductId).First();
                cartItem.Purchase = purchase;
                _dbContext.ShoppingCartItems.Add(cartItem);
            }

            var data = Mapper.Map<PurchaserDataDTO, PurchaserData>(dto.PurchaserDataDTO);
            data.Purchase = purchase;
            _dbContext.PurchaserDatas.Add(data);
        }

        private void Validate(PurchaseDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException("Function argument can not be null");

            var cost = 0;
            foreach (var el in dto.ShoppingCartItemDTOs)
            {
                cost += el.Quantity * _dbContext.Products.Where(p => p.Id == el.ProductId).First().Price;
            }
            if (dto.ProductsCost != cost)
                throw new ArgumentException("Invalid purchase cost parameter");
        }
    }
}