using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.ViewModels.BarberServices;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Controllers
{
    public class BarberServicesController : BaseController
    {
        private readonly IBarberServicesService barberServices;

        public BarberServicesController(IBarberServicesService barberServices)
        {
            this.barberServices = barberServices;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BarberServicesListViewModel
            {
                BarberServices = await this.barberServices.GetAllAsync<BarberServiceViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
