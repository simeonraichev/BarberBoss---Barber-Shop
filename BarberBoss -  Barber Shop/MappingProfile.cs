using AutoMapper;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.ViewModels.BarberShops;

namespace BarberBoss____Barber_Shop
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<BarberShop, BarberShopViewModel>();

            this.CreateMap<BarberShopViewModel, BarberShop>();

        }
    }
}
