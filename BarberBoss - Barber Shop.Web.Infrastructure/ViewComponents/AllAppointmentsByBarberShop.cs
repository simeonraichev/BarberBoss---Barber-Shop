using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.ViewModels.Appointments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class AllAppointmentsByBarberShop : ViewComponent
    {
        private readonly IAppointmentsService appointmentsService;

        public AllAppointmentsByBarberShop(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string barberShopId)
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllByBarberShopAsync<AppointmentsViewModel>(barberShopId),
            };

            return this.View(viewModel);
        }
    }
}
