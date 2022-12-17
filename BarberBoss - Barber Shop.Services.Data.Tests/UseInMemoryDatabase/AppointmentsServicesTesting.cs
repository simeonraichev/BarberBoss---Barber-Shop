using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Data.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BarberBoss___Barber_Shop.Services.Data.Tests.UseInMemoryDatabase
{
    public class AppointmentsServicesTesting : BaseTestingClass
    {
        private IAppointmentsService Service => this.ServiceProvider.GetRequiredService<IAppointmentsService>();

        //Task<T> GetByIdAsync<T>(string id);

        //Task<IEnumerable<T>> GetAllAsync<T>();

        //Task<IEnumerable<T>> GetAllByBarberShopAsync<T>(string barberShopId);

        //Task<IEnumerable<T>> GetNextClientByUserAsync<T>(string userId);

        //Task<IEnumerable<T>> GetPastClientByUserAsync<T>(string userId);

        //Task AddAsync(string userId, string barberShopId, int serviceId, DateTime dateTime);

        //Task DeleteAsync(string id);

        //Task ConfirmAsync(string id);

        //Task DeclineAsync(string id);

        //Task RateAppointmentAsync(string id);
        [Fact]
        public async Task ConfirmAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.ConfirmAsync(newGuidId);
            var result = await this.DbContext.Appointments.Where(x => x.Id == newGuidId).Select(x => x.Confirmed).FirstOrDefaultAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.True(result);
        } 
        [Fact]
        public async Task AddAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            await this.CreateAppointmentAsync(newGuidId);

            var dateTime = DateTime.UtcNow.AddDays(5);
            var userId = Guid.NewGuid().ToString();
            var barberShopId = Guid.NewGuid().ToString();
            var serviceId = 1;

            await this.Service.AddAsync(userId, barberShopId, serviceId, dateTime);

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.Equal(2, appointmentsCount);
        }
        [Fact]
        public async Task RateAppointmentTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.RateAppointmentAsync(newGuidId);
            var result = await this.DbContext.Appointments.Where(x => x.Id == newGuidId).Select(x => x.IsBarberShopRatedByTheUser).FirstOrDefaultAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();

            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.DeleteAsync(appointment.Id);

            var appointmentsCount = this.DbContext.Appointments.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedAppointment = await this.DbContext.Appointments.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            Assert.Equal(0, appointmentsCount);
            Assert.Null(deletedAppointment);
        }

        [Fact]
        public async Task DeclineAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.DeclineAsync(newGuidId);
            var result = await this.DbContext.Appointments.Where(x => x.Id == newGuidId).Select(x => x.Confirmed).FirstOrDefaultAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.True(!result);
        }

        private async Task<Appointment> CreateAppointmentAsync(string newGuidId)
        {
            var appointment = new Appointment
            {
                Id = newGuidId,
                DateTime = DateTime.UtcNow.AddDays(5),
                UserId = Guid.NewGuid().ToString(),
                BarberShopId = Guid.NewGuid().ToString(),
                ServiceId = 1,
            };

            await this.DbContext.Appointments.AddAsync(appointment);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Appointment>(appointment).State = EntityState.Detached;
            return appointment;
        }
    }
}
