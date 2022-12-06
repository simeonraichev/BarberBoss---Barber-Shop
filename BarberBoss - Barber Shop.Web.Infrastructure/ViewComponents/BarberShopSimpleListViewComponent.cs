using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.ViewModels.BarberShops;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class BarberShopSimpleListViewComponent : ViewComponent
    {
        private readonly IBarberShopsService barberShopsService;

        public BarberShopSimpleListViewComponent(IBarberShopsService barberShopsService)
        {
            this.barberShopsService = barberShopsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // This is used as a Menu in Salon Manager Area
            // Now only the Admin can Add new shops and only the seeded Manager can manage all of them
            // When Registering a BarberShop becomes an option for every user, UserId (OwnerId for Barber Shop) would be checked here
            var viewModel = new BarberShopSimpleViewModel
            {
                BarberShops = await this.barberShopsService.GetAllAsync<BarberShopSimpleViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
