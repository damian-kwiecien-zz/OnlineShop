using AutoMapper;
using OnlineShop.App_Start.MapperProfiles;

namespace OnlineShop.App_Start
{
    public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<OnlineShopProfile>();
            });
        }
    }
}