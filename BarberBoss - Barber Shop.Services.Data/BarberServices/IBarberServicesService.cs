using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.BarberServices
{
    public interface IBarberServicesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task AddAsync(string name, string description, string imageUrl);

        Task<T> GetByIdAsync<T>(int id);

        Task DeleteAsync(int id);
    }
}
