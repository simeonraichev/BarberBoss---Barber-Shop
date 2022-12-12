using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Mapping;
using Microsoft.EntityFrameworkCore;



namespace BarberBoss___Barber_Shop.Services.Data.BarberShops
{
    public class BarberShopsService : IBarberShopsService
    {
        private readonly IDeletableEntityRepository<BarberShop> barberShopRepository;

        public BarberShopsService(IDeletableEntityRepository<BarberShop> barbershopRepository)
        {
            this.barberShopRepository = barbershopRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var barberShops =
                await this.barberShopRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>().ToListAsync(); ;
            return barberShops;
        }

        public async Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<BarberShop> query =
                this.barberShopRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Name);  
                
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Name.ToLower()
                                .Contains(searchString.ToLower()));
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .To<T>().ToListAsync();
        }

        public async Task<int> GetCountForPaginationAsync(string searchString, int? sortId)
        {
            IQueryable<BarberShop> query =
                this.barberShopRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Name.ToLower()
                                .Contains(searchString.ToLower()));
            }
                       
            return await query.CountAsync();
        }

        public async Task<IEnumerable<string>> GetAllIdsByBarberServiceAsync(int barberServiceId)
        {
            var barberShopsIds =
                await this.barberShopRepository
                .All()
                .Where(x => x.BarberServiceId == barberServiceId)
                .Select(x => x.Id)
                .ToListAsync();
            return barberShopsIds;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var barberShop =
                await this.barberShopRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return barberShop;
        }

        public async Task<string> AddAsync(string name, int barberServiceId, int townId, string address, string imageUrl)
        {
            var barberShop = new BarberShop
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                TownId = townId,
                Address = address,
                ImageUrl = imageUrl,
                Rating = 0,
                RatersCount = 0,
            };

            await this.barberShopRepository.AddAsync(barberShop);
            await this.barberShopRepository.SaveChangesAsync();
            return barberShop.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var barberShop =
                await this.barberShopRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.barberShopRepository.Delete(barberShop);
            await this.barberShopRepository.SaveChangesAsync();
        }

        public async Task RateBarberShopAsync(string id, int rateValue)
        {
            var barberShop =
                await this.barberShopRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var oldRating = barberShop.Rating;
            var oldRatersCount = barberShop.RatersCount;

            var newRatersCount = oldRatersCount + 1;
            var newRating = (oldRating + rateValue) / newRatersCount;

            barberShop.Rating = newRating;
            barberShop.RatersCount = newRatersCount;

            await this.barberShopRepository.SaveChangesAsync();
        }
    }
}
