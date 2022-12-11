using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.Services
{
    public interface IServicesService
    {

        Task<IEnumerable<int>> GetAllIdsByBarberServiceAsync(int barberServiceId);

        Task<int> AddAsync(string name, int barberServiceId, string description);

        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllAsync<T>();

    }
}
