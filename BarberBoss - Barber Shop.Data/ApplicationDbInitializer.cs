using BarberBoss___Barber_Shop.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                
                //Towns
                if(!context.Towns.Any())
                {
                    context.Towns.AddRange(new List<Town>()
                    {
                        new Town()
                        {
                            Name = "Sofia",
                        },
                        new Town()
                        {
                            Name = "Plovdiv"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new List<ApplicationRole>()
                   {
                       new ApplicationRole()
                       {
                           Name = "Administrator"
                       },
                       new ApplicationRole()
                       {
                           Name = "Barber"
                       }
                   });
                }

                context.SaveChanges();
                //BarberShops
                //if (!context.BarberShops.Any())
                //{
                //    context.BarberShops.AddRange(new List<BarberShop>()
                //    {
                //        new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - NDK",
                //        TownId = 1,
                //        Address = "Bul. Vitosha 12",
                //        ImageUrl = "https://d2zdpiztbgorvt.cloudfront.net/region1/us/300873/biz_photo/13b146ff8589428d9f94112d0d93cf-royce-barbershop-biz-photo-48b14ca5802e4d9d96cc65bbbb1af8-booksy.jpeg",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },
                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Reduta",
                //        TownId = 1,
                //        Address = "ul. Chernica 15",
                //        ImageUrl = "https://www.winemag.com/wp-content/uploads/2022/01/HERO_Barbershop_Cuts_and_Cocktails_Credit_David_J_Crewe_1920x1280.jpg",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },
                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Serdika",
                //        TownId = 2,
                //        Address = "bul. Serdika 145",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },

                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Nadejda 3",
                //        TownId = 1,
                //        Address = "bul. Lomsko Shose 43",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },
                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Lozenec",
                //        TownId = 1,
                //        Address = "ul. Milin Kamuk 13",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },
                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Ivan Vazov",
                //        TownId = 2,
                //        Address = "ul. Ivan Vazov 22",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },

                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Mall Sofia",
                //        TownId = 1,
                //        Address = "bul. Opulchenska 1",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },
                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Paradice Center",
                //        TownId = 1,
                //        Address = "bul. Cherni vrah 123",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },
                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Boyana",
                //        TownId = 2,
                //        Address = "ul. Konyuvica 17",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    },

                //    new BarberShop
                //    {
                //        Id = "seeded" + Guid.NewGuid().ToString(),
                //        Name = "Barber Boss - Sveta Troica",
                //        TownId = 1,
                //        Address = "bul. Konstantin Velichkov 67",
                //        ImageUrl = "",
                //        OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                //        Rating = 0.0,
                //        RatersCount = 0,
                //    }
                //    });
                //    context.SaveChanges();

            //}
            }
        }
    }
}

