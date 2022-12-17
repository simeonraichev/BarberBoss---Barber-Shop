using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.Services.Data.BarberShopsServices;
using BarberBoss___Barber_Shop.Services.Data.Services;
using BarberBoss___Barber_Shop.ViewModels.Common.SelectableItems;
using BarberBoss___Barber_Shop.ViewModels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    public class ServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;
        private readonly IBarberServicesService barberServicesService;
        private readonly IBarberShopsService barberShopsService;
        private readonly IBarberShopsServicesService barberShopsServicesService;

        public ServicesController(
            IServicesService servicesService,
            IBarberServicesService barberServicesService,
            IBarberShopsService barberShopsService,
            IBarberShopsServicesService barberShopsServicesService)
        {
            this.servicesService = servicesService;
            this.barberServicesService = barberServicesService;
            this.barberShopsService = barberShopsService;
            this.barberShopsServicesService = barberShopsServicesService;
        }


        [HttpPost]
        public async Task<IActionResult> AddService(ServiceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // Add Service
            var serviceId = await this.servicesService.AddAsync(input.Name, input.BarberServiceId, input.Description);

            var barberShopsIds = await this.barberShopsService.GetAllIdsByBarberServiceAsync(input.BarberServiceId);
            await this.barberShopsServicesService.AddAsync(barberShopsIds, serviceId);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (id <= 51)
            {
                return this.RedirectToAction("Index");
            }

            await this.servicesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new ServicesListViewModel
            {
                Services = await this.servicesService.GetAllAsync<ServiceViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddService()
        {
            var categories = await this.barberServicesService.GetAllAsync<BarberServiceSelectListViewModel>();
            this.ViewData["BarberServices"] = new SelectList(categories, "Id", "Name");

            return this.View();
        }

    }
}
