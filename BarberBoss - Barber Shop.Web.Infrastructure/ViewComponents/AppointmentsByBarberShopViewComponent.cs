﻿using BarberBoss___Barber_Shop.Services.Data.Appointments;
using BarberBoss___Barber_Shop.ViewModels.Appointments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Web.Infrastructure.ViewComponents
{
    public class AppointmentsByBarberShopViewComponent : ViewComponent
    {
        private readonly IAppointmentsService appointmentsService;

        public AppointmentsByBarberShopViewComponent(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string salonId)
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllByBarberShopAsync<AppointmentsViewModel>(salonId),
            };

            return this.View(viewModel);
        }
    }
}