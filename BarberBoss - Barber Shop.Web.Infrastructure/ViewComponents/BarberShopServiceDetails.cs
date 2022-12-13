using BarberBoss___Barber_Shop.Services.Data.BarberShopsServices;
using BarberBoss___Barber_Shop.ViewModels.BarberShopsServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class BarberShopServiceDetails : ViewComponent
    {
        private readonly IBarberShopsServicesService barberShopsServicesService;

        public BarberShopServiceDetails(IBarberShopsServicesService barberShopsServicesService)
        {
            this.barberShopsServicesService = barberShopsServicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string barberShopId, int serviceId)
        {
            var viewModel =
                await this.barberShopsServicesService.GetByIdAsync<BarberShopsServiceDetailsViewModel>(barberShopId, serviceId);

            return this.View(viewModel);
        }
    }
}
