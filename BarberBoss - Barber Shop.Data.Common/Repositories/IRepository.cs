using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Common.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> AllAsNoTracking();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
