using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using OnlineShop.DTOs;
using OnlineShop.Entities;
using OnlineShop.Models;
using System;
using System.Linq;
using System.Web;

namespace OnlineShop.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly OnlineShopDbContext _dbContext;
        private readonly ProductService _productService;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public PurchaseService(OnlineShopDbContext dbContext, ApplicationUserManager userManager, ProductService productService)
        {
            _dbContext = dbContext;
            UserManager = userManager;
        }

        public void AddPurchase(PurchaseDTO dto)
        {

            Validate(dto);

            var purchase = Mapper.Map<PurchaseDTO, Purchase>(dto);
            purchase.Pending = true;

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
                throw new ArgumentException("Invalid function parameter");
        }
    }
}