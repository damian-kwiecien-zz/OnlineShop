using AutoMapper;
using OnlineShop.DTOs;
using OnlineShop.Entities;
using System.Linq;

namespace OnlineShop.App_Start.MapperProfiles
{
    public class OnlineShopProfile : Profile
    {
        public OnlineShopProfile()
        {
            MapProductToProductDTO();
            MapPurchaseDTOToPurchase();
            MapShoppingCartItemDTOToShoppingCartItem();
            MapPurchaserDataDTOToPurchaserData();
        }

        private void MapProductToProductDTO()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Target,
                opts => opts.MapFrom(src => src.Target.Name))
                .ForMember(dest => dest.Category,
                opts => opts.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Type,
                opts => opts.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.ImagesUrl,
                opts => opts.MapFrom(src => src.Image.Select(img => img.ImgUrl)));
        }

        private void MapPurchaseDTOToPurchase()
        {
            CreateMap<PurchaseDTO, Purchase>();
        }

        private void MapShoppingCartItemDTOToShoppingCartItem()
        {
            CreateMap<ShoppingCartItemDTO, ShoppingCartItem>();
        }

        private void MapPurchaserDataDTOToPurchaserData()
        {
            CreateMap<PurchaserDataDTO, PurchaserData>();
        }
    }
}