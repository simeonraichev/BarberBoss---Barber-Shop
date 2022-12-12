using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.BarberShopsServices
{
    public interface IBarberShopsServicesService
    {
        Task<T> GetByIdAsync<T>(string barberShopId, int serviceId);

        Task AddAsync(string barberShopId, IEnumerable<int> servicesIds);

        Task AddAsync(IEnumerable<string> barberShopIds, int serviceId);

        Task ChangeAvailableStatusAsync(string barberShopId, int serviceId);
    }
}
