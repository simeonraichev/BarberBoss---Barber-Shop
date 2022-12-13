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
    public class BarberShopSimpleList : ViewComponent
    {
        private readonly IBarberShopsService barberShopsService;

        public BarberShopSimpleList(IBarberShopsService barberShopsService)
        {
            this.barberShopsService = barberShopsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // This is used as a Menu in BarberShop Manager Area
            // Now only the Admin can Add new shops and only the seeded Manager can manage all of them
            // When Registering a BarberShop becomes an option for every user, UserId (OwnerId for Barber Shop) would be checked here
            var viewModel = new BarberShopsSimpleListViewModel
            {
                BarberShops = await this.barberShopsService.GetAllAsync<BarberShopsSimpleViewModel>()
            };

            return this.View(viewModel);
        }
    }
}
