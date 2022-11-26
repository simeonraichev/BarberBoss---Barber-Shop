using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Mapping;
using Microsoft.EntityFrameworkCore;



namespace BarberBoss___Barber_Shop.Services.Data.BarberShops
{
    public class BarberShopsService
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

            if (sortId != null)
            {
                query = query
                    .Where(x => x.CategoryId == sortId);
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

            if (sortId != null)
            {
                query = query
                    .Where(x => x.CategoryId == sortId);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<string>> GetAllIdsByCategoryAsync(int categoryId)
        {
            var salonsIds =
                await this.barberShopRepository
                .All()
                .Where(x => x.CategoryId == categoryId)
                .Select(x => x.Id)
                .ToListAsync();
            return salonsIds;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var salon =
                await this.barberShopRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return salon;
        }

        public async Task<string> AddAsync(string name, int categoryId, int townId, string address, string imageUrl)
        {
            var salon = new BarberShop
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                CategoryId = categoryId,
                TownId = townId,
                Address = address,
                ImageUrl = imageUrl,
                Rating = 0,
                RatersCount = 0,
            };

            await this.barberShopRepository.AddAsync(salon);
            await this.barberShopRepository.SaveChangesAsync();
            return salon.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var salon =
                await this.barberShopRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.barberShopRepository.Delete(salon);
            await this.barberShopRepository.SaveChangesAsync();
        }

        public async Task RateSalonAsync(string id, int rateValue)
        {
            var salon =
                await this.barberShopRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var oldRating = salon.Rating;
            var oldRatersCount = salon.RatersCount;

            var newRatersCount = oldRatersCount + 1;
            var newRating = (oldRating + rateValue) / newRatersCount;

            salon.Rating = newRating;
            salon.RatersCount = newRatersCount;

            await this.barberShopRepository.SaveChangesAsync();
        }
    }
}
