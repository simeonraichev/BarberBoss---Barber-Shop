using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
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
    public class BarberShopsServicesTests : BaseTestingClass
    {
        private IBarberShopsService Service => this.ServiceProvider.GetRequiredService<IBarberShopsService>();


        private async Task<BarberShop> CreateBarberShopAsync(string newGuidId)
        {
            var barberShop = new BarberShop
            {
                Id = newGuidId,
                Name = new NLipsum.Core.Sentence().ToString(),
                BarberServiceId = 1,
                TownId = 1,
                Address = new NLipsum.Core.Sentence().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                Rating = 4,
                RatersCount = 1,
            };

            await this.DbContext.BarberShops.AddAsync(barberShop);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<BarberShop>(barberShop).State = EntityState.Detached;
            return barberShop;
        }

        [Fact]
        public async Task GetAllIdsByBarberServiceAsyncTest()
        {
            var barberShop1 = new BarberShop
            {
                Id = Guid.NewGuid().ToString(),
                Name = new NLipsum.Core.Sentence().ToString(),
                BarberServiceId = 5,
                TownId = 1,
                Address = new NLipsum.Core.Sentence().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                Rating = 4,
                RatersCount = 1,
            };
            var barberShop2 = new BarberShop
            {
                Id = Guid.NewGuid().ToString(),
                Name = new NLipsum.Core.Sentence().ToString(),
                BarberServiceId = 5,
                TownId = 1,
                Address = new NLipsum.Core.Sentence().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                Rating = 4,
                RatersCount = 1,
            };
            var barberShop3 = new BarberShop
            {
                Id = Guid.NewGuid().ToString(),
                Name = new NLipsum.Core.Sentence().ToString(),
                BarberServiceId = 5,
                TownId = 1,
                Address = new NLipsum.Core.Sentence().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                Rating = 4,
                RatersCount = 1,
            };

            await this.DbContext.BarberShops.AddRangeAsync(barberShop1, barberShop2, barberShop3);
            await this.DbContext.SaveChangesAsync();

            var expected = this.DbContext.BarberShops.Where(x => x.BarberServiceId == 5).Count();
            var actual = await this.Service.GetAllIdsByBarberServiceAsync(5);
            var actualCount = 0;
            foreach (var result in actual)
            {
                actualCount++;
            }

            Assert.Equal(expected, actualCount);
        }



        [Fact]
        public async Task GetCountForPaginationAsyncTest()
        {
            await this.CreateBarberShopAsync(Guid.NewGuid().ToString());
            await this.CreateBarberShopAsync(Guid.NewGuid().ToString());
            await this.CreateBarberShopAsync(Guid.NewGuid().ToString());

            var actual = await this.Service.GetCountForPaginationAsync(" ", 0);
            Assert.Equal(0, actual);
        }

        [Fact]
        public async Task AddAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            await this.CreateBarberShopAsync(newGuidId);

            var name = new NLipsum.Core.Sentence().ToString();
            var categoryId = 1;
            var cityId = 1;
            var address = new NLipsum.Core.Sentence().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(name, categoryId, cityId, address, imageUrl);

            var salonsCount = await this.DbContext.BarberShops.CountAsync();
            Assert.Equal(2, salonsCount);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();

            var salon = await this.CreateBarberShopAsync(newGuidId);

            await this.Service.DeleteAsync(salon.Id);

            var salonsCount = this.DbContext.BarberShops.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedSalon = await this.DbContext.BarberShops.FirstOrDefaultAsync(x => x.Id == salon.Id);
            Assert.Equal(0, salonsCount);
            Assert.Null(deletedSalon);
        }

        [Fact]
        public async Task RateSalonAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var salon = await this.CreateBarberShopAsync(newGuidId);

            var rateValue = 4;
            await this.Service.RateBarberShopAsync(newGuidId, rateValue);

            var expected = rateValue;
            var actual = salon.Rating;

            Assert.Equal(expected, actual);
        }

    }
}
