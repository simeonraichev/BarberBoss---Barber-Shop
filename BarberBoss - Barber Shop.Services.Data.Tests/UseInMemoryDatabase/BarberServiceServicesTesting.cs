using BarberBoss___Barber_Shop.Data.Models;
using BarberBoss___Barber_Shop.Services.Data.BarberServices;
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
    public class BarberServiceServicesTesting : BaseTestingClass
    {
        private IBarberServicesService Service => this.ServiceProvider.GetRequiredService<IBarberServicesService>();


        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var barberService = await this.CreateBarberServiceAsync();

            await this.Service.DeleteAsync(barberService.Id);

            var barberServicesCount = this.DbContext.BarberServices.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedBarberService = await this.DbContext.BarberServices.FirstOrDefaultAsync(x => x.Id == barberService.Id);
            Assert.Equal(0, barberServicesCount);
            Assert.Null(deletedBarberService);
        }

        private async Task<BarberService> CreateBarberServiceAsync()
        {
            var barberService = new BarberService
            {
                Name = new NLipsum.Core.Sentence().ToString(),
                Description = new NLipsum.Core.Paragraph().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
            };

            await this.DbContext.BarberServices.AddAsync(barberService);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<BarberService>(barberService).State = EntityState.Detached;
            return barberService;
        }

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateBarberServiceAsync();

            var name = new NLipsum.Core.Sentence().ToString();
            var description = new NLipsum.Core.Paragraph().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(name, description, imageUrl);

            var barberServiceCount = await this.DbContext.BarberServices.CountAsync();
            Assert.Equal(2, barberServiceCount);
        }
    }
}
