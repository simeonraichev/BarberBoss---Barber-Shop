using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.Appointments
{
    public interface IAppointmentsService
    {
        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByBarberShopAsync<T>(string barberShopId);


        Task<IEnumerable<T>> GetPastClientByUserAsync<T>(string userId);

        Task AddAsync(string userId, string barberShopId, int serviceId, DateTime dateTime);

        Task<IEnumerable<T>> GetNextClientByUserAsync<T>(string userId);

        Task ConfirmAsync(string id);

        Task DeclineAsync(string id);

        Task DeleteAsync(string id);
        Task RateAppointmentAsync(string id);
    }
}
