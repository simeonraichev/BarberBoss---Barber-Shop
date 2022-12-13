using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.Services.Data.BarberShopsServices;
using BarberBoss___Barber_Shop.ViewModels.BarberShops;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Barber.Controllers
{
    public class BarberShopsController : BarberBaseController
    {
        private readonly IBarberShopsService barberShopsService;
        private readonly IBarberShopsServicesService barberShopsServicesService;
        private readonly IAppointmentsService appointmentsService;

        public BarberShopsController(
            IBarberShopsService barberShopsService,
            IBarberShopsServicesService barberShopsServicesService,
            IAppointmentsService appointmentsService)
        {
            this.barberShopsService = barberShopsService;
            this.barberShopsServicesService = barberShopsServicesService;
            this.appointmentsService = appointmentsService;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(string id, string barberShopId)
        {
            await this.appointmentsService.ConfirmAsync(id);
            return this.RedirectToAction("Details", new { id = barberShopId });
        }

        [HttpPost]
        public async Task<IActionResult> DeclineAppointment(string id, string barberShopId)
        {
            await this.appointmentsService.DeclineAsync(id);
            return this.RedirectToAction("Details", new { id = barberShopId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.barberShopsService.GetByIdAsync<BarberShopWithServicesViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeServiceAvailableStatus(string barberShopId, int serviceId)
        {
            await this.barberShopsServicesService.ChangeAvailableStatusAsync(barberShopId, serviceId);

            return this.RedirectToAction("Details", new { id = barberShopId });
        }

        
    }
}
