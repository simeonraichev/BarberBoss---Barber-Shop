using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.Appointments
{
    internal class AppointmentsService : IAppointmentsService
    {
        public Task AddAsync(string userId, string barberShopId, int serviceId, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task ConfirmAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeclineAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllByBarberShopAsync<T>(string salonId)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetNextClientByUserAsync<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPastClietByUserAsync<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RateAppointmentAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
