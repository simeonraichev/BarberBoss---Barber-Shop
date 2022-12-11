using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.Towns
{
    public interface ITownService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task AddAsync(string name);

        Task DeleteAsync(int id);
    }
}
