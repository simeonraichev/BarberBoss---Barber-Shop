using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.BarberShopsServices
{
    public class BarberShopsServicesService : IBarberShopsServicesService
    {
        private readonly IDeletableEntityRepository<BarberShopsService> barberShopsServicesRepository;

        public BarberShopsServicesService(IDeletableEntityRepository<BarberShopsService> barberShopsServicesRepository)
        {
            this.barberShopsServicesRepository = barberShopsServicesRepository;
        }

        public async Task<T> GetByIdAsync<T>(string barberShopId, int serviceId)
        {
            var salonService =
                await this.barberShopsServicesRepository
                .All()
                .Where(x => x.BarberShopId == barberShopId && x.ServiceId == serviceId)
                .To<T>().FirstOrDefaultAsync();
            return salonService;
        }

        public async Task AddAsync(string barberShopId, IEnumerable<int> servicesIds)
        {
            foreach (var serviceId in servicesIds)
            {
                await this.barberShopsServicesRepository.AddAsync(new BarberShopsService
                {
                    BarberShopId = barberShopId,
                    ServiceId = serviceId,
                    Available = true,
                });
            }

            await this.barberShopsServicesRepository.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<string> barberShopIds, int serviceId)
        {
            foreach (var barberShopId in barberShopIds)
            {
                await this.barberShopsServicesRepository.AddAsync(new BarberShopsService
                {
                    BarberShopId = barberShopId,
                    ServiceId = serviceId,
                    Available = true,
                });
            }

            await this.barberShopsServicesRepository.SaveChangesAsync();
        }

        public async Task ChangeAvailableStatusAsync(string barberShopId, int serviceId)
        {
            var barberShopService =
                await this.barberShopsServicesRepository
                .All()
                .Where(x => x.BarberShopId == barberShopId
                            && x.ServiceId == serviceId)
                .FirstOrDefaultAsync();

            barberShopService.Available = !barberShopService.Available;

            await this.barberShopsServicesRepository.SaveChangesAsync();
        }
    }
}
