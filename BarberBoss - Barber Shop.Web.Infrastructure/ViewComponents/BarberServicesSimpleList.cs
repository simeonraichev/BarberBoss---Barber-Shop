using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.ViewModels.BarberServices;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class BarberServicesSimpleList : ViewComponent
    {
        private readonly IBarberServicesService barberServicesService;

        public BarberServicesSimpleList(IBarberServicesService barberServicesService)
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
