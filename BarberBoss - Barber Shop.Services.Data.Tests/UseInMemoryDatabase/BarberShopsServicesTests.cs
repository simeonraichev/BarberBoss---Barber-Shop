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
            var barberServiceId = 1;
            var townId = 1;
            var address = new NLipsum.Core.Sentence().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(name, barberServiceId, townId, address, imageUrl);

            var barberShopsCount = await this.DbContext.BarberShops.CountAsync();
            Assert.Equal(2, barberShopsCount);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();

            var barberShop = await this.CreateBarberShopAsync(newGuidId);

            await this.Service.DeleteAsync(barberShop.Id);

            var barberShopsCount = this.DbContext.BarberShops.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedBarberShop = await this.DbContext.BarberShops.FirstOrDefaultAsync(x => x.Id == barberShop.Id);
            Assert.Equal(0, barberShopsCount);
            Assert.Null(deletedBarberShop);
        }

        [Fact]
        public async Task RateBarberShopAsyncTest()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var barberShop = await this.CreateBarberShopAsync(newGuidId);

            var rateValue = 4;
            await this.Service.RateBarberShopAsync(newGuidId, rateValue);

            var expected = rateValue;
            var actual = barberShop.Rating;

            Assert.Equal(expected, actual);
        }

    }
}
