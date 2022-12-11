﻿using BarberBoss___Barber_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Seeding.CustomSeeding
{
    public class AppointmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Appointments.Any())
            {
                return;
            }

            var appointments = new List<Appointment>();

            // Get User Id
            var userId = dbContext.Users.Where(x => x.Email == "user@user.com").FirstOrDefault().Id;

            // Get Salons Ids
            var barberShopsIds = await dbContext.BarberShops.Select(x => x.Id).Take(10).ToListAsync();

            foreach (var salonId in barberShopsIds)
            {
                // Get a Service from each Salon
                var serviceId = dbContext.BarberShopsServices.Where(x => x.BarberShopId == salonId).FirstOrDefault().ServiceId;

                // Add Upcoming Appointments
                appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid().ToString(),

                    DateTime = DateTime.UtcNow.AddDays(5),
                    UserId = userId,
                    BarberShopId = salonId,
                    ServiceId = serviceId,
                });

                // Add Past Appointments
                appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTime = DateTime.UtcNow.AddDays(-5),
                    UserId = userId,
                    BarberShopId = salonId,
                    ServiceId = serviceId,
                    Confirmed = true,
                });

                // More Past Appointments for testing the RatePastAppointment option
                appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTime = DateTime.UtcNow.AddDays(-10),
                    UserId = userId,
                    BarberShopId = salonId,
                    ServiceId = serviceId,
                    Confirmed = true,
                });
            }

            await dbContext.AddRangeAsync(appointments);
        }
    }
}
