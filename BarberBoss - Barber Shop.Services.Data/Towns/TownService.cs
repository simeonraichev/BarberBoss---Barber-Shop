using BarberBoss___Barber_Shop.Data.Common.Repositories;
using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.Towns
{
    public class TownService : ITownService
    {
        private readonly IDeletableEntityRepository<Town> townsRepository;

        public TownService(IDeletableEntityRepository<Town> townsRepository)
        {
            this.townsRepository = townsRepository;
        }
       
        public async Task DeleteAsync(int id)
        {
            var town =
                await this.townsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.townsRepository.Delete(town);
            await this.townsRepository.SaveChangesAsync();
        }
        public async Task AddAsync(string name)
        {
            await this.townsRepository.AddAsync(new Town
            {
                Name = name,
            });
            await this.townsRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var cities =
                await this.townsRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return cities;
        }
    }
}
