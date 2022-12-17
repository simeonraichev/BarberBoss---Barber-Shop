using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IDeletableEntityRepository<Service> servicesRepository;

        public ServicesService(IDeletableEntityRepository<Service> servicesRepository)
        {
            this.servicesRepository = servicesRepository;
        }

        public async Task<int> AddAsync(string name, int barberServiceIdId, string description)
        {
            var barberService = new Service
            {
                Name = name,
                BarberServiceId = barberServiceIdId,
                Description = description,
            };
            await this.servicesRepository.AddAsync(barberService);
            await this.servicesRepository.SaveChangesAsync();
            return barberService.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var barberService =
                await this.servicesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.servicesRepository.Delete(barberService);
            await this.servicesRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<int>> GetAllIdsByBarberServiceAsync(int barberServiceIdId)
        {
            ICollection<int> servicesIds =
                await this.servicesRepository
                .All()
                .Where(x => x.BarberServiceId == barberServiceIdId)
                .OrderBy(x => x.Id)
                .Select(x => x.Id)
                .ToListAsync();
            return servicesIds;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var barberServices =
                await this.servicesRepository
                .All()
                .OrderBy(x => x.BarberServiceId)
                .ThenBy(x => x.Id)
                .To<T>().ToListAsync();
            return barberServices;
        }
    }
}
