using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.ViewModels.BarberServices;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    public class BarberServicesController : AdministrationController
    {
        private readonly IBarberServicesService barberServicesService;
        public IActionResult AddBarberService()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBarberService(BarberServiceInputModel input)
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

            await this.barberServicesService.AddAsync(input.Name, input.Description, imageUrl);
            return this.RedirectToAction("Index");
        }
        public BarberServicesController(
            IBarberServicesService barberServicesService)
        {
            this.barberServicesService = barberServicesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BarberServicesListViewModel
            {
                BarberServices = await this.barberServicesService.GetAllAsync<BarberServiceViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBarberService(int id)
        {
            if (id <= 6)
            {
                return this.RedirectToAction("Index");
            }

            await this.barberServicesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
