using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.ViewModels.Appointments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class PastAppointmentsViewComponent : ViewComponent
    {
        private readonly IAppointmentsService appointmentsService;
        private readonly UserManager<MyApplicationUser> userManager;

        public PastAppointmentsViewComponent(
            IAppointmentsService appointmentsService,
            UserManager<MyApplicationUser> userManager)
        {
            this.appointmentsService = appointmentsService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetPastClientByUserAsync<AppointmentsViewModel>(userId),
            };

            return this.View(viewModel);
        }
    }
}
