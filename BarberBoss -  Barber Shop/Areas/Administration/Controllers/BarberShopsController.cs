using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.Services.Data.BarberShopsServices;
using BarberBoss___Barber_Shop.Services.Data.Services;
using BarberBoss___Barber_Shop.Services.Data.Towns;
using BarberBoss___Barber_Shop.ViewModels.BarberShops;
using BarberBoss___Barber_Shop.ViewModels.Common.SelectableItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    public class BarberShopsController : AdministrationController
    {
        private readonly IBarberShopsService barberShopsService;
        private readonly IBarberServicesService barberServicesService;
        private readonly ITownService townService;
        private readonly IServicesService servicesService;
        private readonly IBarberShopsServicesService barberShopsServicesService;

        public BarberShopsController(
            IBarberShopsService barberShopsService,
            IBarberServicesService barberServicesService,
            ITownService townService,
            IServicesService servicesService,
            IBarberShopsServicesService barberShopsServicesService)
        {
            this.barberShopsService = barberShopsService;
            this.barberServicesService = barberServicesService;
            this.townService = townService;
            this.servicesService = servicesService;
            this.barberShopsServicesService = barberShopsServicesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BarberShopsListViewModel
            {
                BarberShops = await this.barberShopsService.GetAllAsync<BarberShopViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddSalon()
        {
            var barberServives = await this.barberServicesService.GetAllAsync<BarberServiceSelectListViewModel>();
            var towns = await this.townService.GetAllAsync<TownSelectListViewModel>();

            this.ViewData["BarberServices"] = new SelectList(barberServives, "Id", "Name");
            this.ViewData["Towns"] = new SelectList(towns, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBarberShop(BarberShopsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl = "https://media.wired.com/photos/5b899992404e112d2df1e94e/master/pass/trash2-01.jpg";
            //try
            //{
            //    imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Name);
            //}
            //catch (System.Exception)
            //{
            //    // In case of missing Cloudinary configuration from appsettings.json
            //    imageUrl = GlobalConstants.Images.CloudinaryMissing;
            //}

            // Add BarberShop
            var salonId = await this.barberShopsService.AddAsync(input.Name, input.CategoryId, input.CityId, input.Address, imageUrl);

            // Add to the Salon all Services from its Category
            var servicesIds = await this.servicesService.GetAllIdsByBarberServiceAsync(input.CategoryId);
            await this.barberShopsServicesService.AddAsync(salonId, servicesIds);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBarberShop(string id)
        {
            if (id.StartsWith("seeded"))
            {
                return this.RedirectToAction("Index");
            }

            await this.barberShopsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
