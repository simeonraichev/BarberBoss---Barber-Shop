using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.ViewModels.BarberServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class BarberServicesSimpleListViewComponent : ViewComponent
    {
        private readonly IBarberServicesService barberServicesService;

        public BarberServicesSimpleListViewComponent(IBarberServicesService barberServicesService)
        {
            this.barberServicesService = barberServicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new BarberServicesSimpleListViewModel
            {
                BarberServices = await this.barberServicesService.GetAllAsync<BarberServiceSimpleViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
