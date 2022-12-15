using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.Services.Data.BarberShopsServices;
using BarberBoss___Barber_Shop.Services.DateTimeParser;
using BarberBoss___Barber_Shop.ViewModels.Appointments;
using BarberBoss___Barber_Shop.ViewModels.BarberShopsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Controllers
{
    [Authorize]
    public class AppointmentsController : BaseController
    {
        private readonly UserManager<MyApplicationUser> userManager;
        private readonly IDateTimeParserService dateTimeParserService;
        private readonly IBarberShopsService barberShopsService;
        private readonly IAppointmentsService appointmentsService;
        private readonly IBarberShopsServicesService barberShopsServicesService;

        public AppointmentsController(
            UserManager<MyApplicationUser> userManager,
            IAppointmentsService appointmentsService,
            IBarberShopsServicesService barberShopsServicesService,
            IDateTimeParserService dateTimeParserService,
            IBarberShopsService barberShopsService)
        {
            this.userManager = userManager;
            this.appointmentsService = appointmentsService;
            this.barberShopsServicesService = barberShopsServicesService;
            this.dateTimeParserService = dateTimeParserService;
            this.barberShopsService = barberShopsService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetNextClientByUserAsync<AppointmentsViewModel>(userId),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> BookAnAppointment(string barberShopId, int serviceId)
        {
            var barberShopService = await this.barberShopsServicesService.GetByIdAsync<BarberShopsServiceSimpleViewModel>(barberShopId, serviceId);
            if (barberShopService == null || !barberShopService.Available)
            {
                return this.View("CantBeUsedRightNow");
            }

            var viewModel = new AppointmentsInputModel
            {
                BarberShopId = barberShopId,
                ServiceId = serviceId,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> BookAnAppointment(AppointmentsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("BookAnAppointment", new { input.BarberShopId, input.ServiceId });
            }

            DateTime dateTime;
            try
            {
                dateTime = this.dateTimeParserService.ConvertStrings(input.Date, input.Time);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("BookAnAppointment", new { input.BarberShopId, input.ServiceId });
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            await this.appointmentsService.AddAsync(userId, input.BarberShopId, input.ServiceId, dateTime);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeclineAppointment(string id)
        {
            var viewModel = await this.appointmentsService.GetByIdAsync<AppointmentsViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            await this.appointmentsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> RateAppointment(string id)
        {
            var viewModel = await this.appointmentsService.GetByIdAsync<AppointmentsRatingViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RateBarberShop(AppointmentsRatingViewModel rating)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("RateAppointment", new { id = rating.Id });
            }

            if (rating.IsBarberShopRatedByTheUser == true)
            {
                return this.RedirectToAction("RateAppointment", new { id = rating.Id });
            }

            await this.appointmentsService.RateAppointmentAsync(rating.Id);
            await this.barberShopsService.RateBarberShopAsync(rating.BarberShopId, rating.RateValue);

            return this.RedirectToAction("Details", "BarberShops", new { id = rating.BarberShopId });
        }
    }
}
