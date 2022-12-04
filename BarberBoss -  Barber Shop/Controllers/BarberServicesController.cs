using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.ViewModels.BarberServices;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Controllers
{
    public class BarberServicesController : BaseController
    {
        private readonly IBarberServices barberServices;

        public BarberServicesController(IBarberServices barberServices)
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
