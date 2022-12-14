using BarberBoss___Barber_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Configuration
{
    public class BarberShopServiceConfiguration : IEntityTypeConfiguration<BarberShopsService>
    {
        public void Configure(EntityTypeBuilder<BarberShopsService> barberShopsService)
        {
            barberShopsService.HasKey(ss => new { ss.BarberShopId, ss.ServiceId });
        }

        //private List<BarberShop> CreateBarberShops()
        //{
        //    List<BarberShop> barberShops = new List<BarberShop>()
        //    {
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - NDK",
        //                    TownId = 1,
        //                    Address = "Bul. Vitosha 12",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Reduta",
        //                    TownId = 1,
        //                    Address = "ul. Chernica 15",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Serdika",
        //                    TownId = 2,
        //                    Address = "bul. Serdika 145",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },

        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Nadejda 3",
        //                    TownId = 1,
        //                    Address = "bul. Lomsko Shose 43",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Lozenec",
        //                    TownId = 1,
        //                    Address = "ul. Milin Kamuk 13",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Ivan Vazov",
        //                    TownId = 2,
        //                    Address = "ul. Ivan Vazov 22",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },

        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Mall Sofia",
        //                    TownId = 1,
        //                    Address = "bul. Opulchenska 1",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Paradice Center",
        //                    TownId = 1,
        //                    Address = "bul. Cherni vrah 123",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },
        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Boyana",
        //                    TownId = 2,
        //                    Address = "ul. Konyuvica 17",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                },

        //                new BarberShop()
        //                {
        //                    Id = "seeded" + Guid.NewGuid().ToString(),
        //                    Name = "Barber Boss - Sveta Troica",
        //                    TownId = 1,
        //                    Address = "bul. Konstantin Velichkov 67",
        //                    ImageUrl = "",
        //                    Rating = 0.0,
        //                    RatersCount = 0,
        //                }
        //    };
        //    return barberShops();
    }
    

}
