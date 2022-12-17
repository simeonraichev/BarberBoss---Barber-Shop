using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Data.Towns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BarberBoss___Barber_Shop.Services.Data.Tests.UseInMemoryDatabase
{
    public class TownsServicesTesting : BaseTestingClass
    {
        private ITownService Service => this.ServiceProvider.GetRequiredService<ITownService>();

        [Fact]
        public async Task AddAsyncTest()
        {
            await this.CreateTownAsync();

            var name = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(name);

            var townsCount = await this.DbContext.Towns.CountAsync();
            Assert.Equal(2, townsCount);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var town = await this.CreateTownAsync();

            await this.Service.DeleteAsync(town.Id);

            var townsCount = this.DbContext.Towns.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedTown = await this.DbContext.Towns.FirstOrDefaultAsync(x => x.Id == town.Id);
            Assert.Equal(0, townsCount);
            Assert.Null(deletedTown);
        }

        private async Task<Town> CreateTownAsync()
        {
            var town = new Town
            {
                Name = new NLipsum.Core.Word().ToString(),
            };

            await this.DbContext.Towns.AddAsync(town);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Town>(town).State = EntityState.Detached;
            return town;
        }
    }
}
