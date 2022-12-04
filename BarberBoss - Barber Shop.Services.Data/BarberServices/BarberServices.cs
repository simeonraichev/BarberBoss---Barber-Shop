
using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.BarberServices
{
    public class BarberServices : IBarberServices
    {
        private readonly IDeletableEntityRepository<BarberService> barberServicesRepository;

        public BarberServices(IDeletableEntityRepository<BarberService> barberServicesRepository)
        {
            this.barberServicesRepository = barberServicesRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<BarberService> query =
                this.barberServicesRepository
                .All()
                .OrderBy(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var barberService =
                await this.barberServicesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return barberService;
        }

        public async Task AddAsync(string name, string description, string imageUrl)
        {
            await this.barberServicesRepository.AddAsync(new BarberService
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
            });
            await this.barberServicesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var barberService =
                await this.barberServicesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.barberServicesRepository.Delete(barberService);
            await this.barberServicesRepository.SaveChangesAsync();
        }
    }
}
