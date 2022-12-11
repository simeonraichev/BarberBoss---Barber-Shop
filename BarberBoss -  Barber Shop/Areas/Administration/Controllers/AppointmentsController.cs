using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.ViewModels.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    public class AppointmentsController : AdministrationController
    {
        private readonly IAppointmentsService appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllAsync<AppointmentsViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
