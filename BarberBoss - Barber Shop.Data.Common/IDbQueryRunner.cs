using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Common
{
    public interface IDbQueryRunner : IDisposable
    {
        Task RunQueryAsync(string query, params object[] parameters);
    }
}
