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
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Towns
                if (!context.Towns.Any())
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
                if (!context.BarberShops.Any())
                {
                    context.BarberShops.AddRange(new List<BarberShop>()
                    {
                        new BarberShop
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Barber Boss - NDK",
                        TownId = 1,
                        Address = "Bul. Vitosha 12",
                        ImageUrl = "https://d2zdpiztbgorvt.cloudfront.net/region1/us/300873/biz_photo/13b146ff8589428d9f94112d0d93cf-royce-barbershop-biz-photo-48b14ca5802e4d9d96cc65bbbb1af8-booksy.jpeg",
                        //OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                        BarberServiceId = 19,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                        new BarberShop
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Barber Boss - Reduta",
                        TownId = 1,
                        Address = "ul. Chernica 15",
                        ImageUrl = "https://heyjoebrand.com/wp-content/uploads/barberia-destacada-does-barbershop-1200x900.jpg",
                        //OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                        BarberServiceId = 20,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                        new BarberShop
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Barber Boss - Serdika",
                        TownId = 2,
                        Address = "bul. Serdika 145",
                        ImageUrl = "https://barrhavenbia.ca/wp-content/uploads/2022/09/Untitled-design-2022-09-14T141023.948-1024x1024.png",
                        //OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                        BarberServiceId = 21,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                        new BarberShop
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Barber Boss - Nadejda 3",
                        TownId = 1,
                        Address = "bul. Lomsko Shose 43",
                        ImageUrl = "https://d2zdpiztbgorvt.cloudfront.net/region1/us/300873/biz_photo/13b146ff8589428d9f94112d0d93cf-royce-barbershop-biz-photo-48b14ca5802e4d9d96cc65bbbb1af8-booksy.jpeg",
                        //OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                        BarberServiceId = 23,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                        new BarberShop
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Barber Boss - Ivan Vazov",
                        TownId = 2,
                        Address = "Bul. Vitosha 12",
                        ImageUrl = "https://static.wixstatic.com/media/8ed53c_637a2be34f964ba396c258e051b55863~mv2.jpeg/v1/fill/w_640,h_660,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/8ed53c_637a2be34f964ba396c258e051b55863~mv2.jpeg",
                        //OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                        BarberServiceId = 24,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                        new BarberShop
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Barber Boss - Lozenec",
                        TownId = 1,
                        Address = "ul. Milin Kamuk 13",
                        ImageUrl = "https://d375139ucebi94.cloudfront.net/region2/es/25009/biz_photo/d61c1f1b09b640d7a51c3f0f417816-the-barbershop-biz-photo-90a2d50d839645778959a2e78f6f92-booksy.jpeg?size=640x427",
                        //OwnerId = "0b65c5b9-9d6c-49cc-bba4-219ee460f66c",
                        BarberServiceId = 19,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    });
                    context.SaveChanges();

                }
                if (!context.BarberServices.Any())
                {
                    context.BarberServices.AddRange(new List<BarberService>()
                    {
                        new BarberService // Id = 1
                    {
                        Name = "Shave & Haircut",
                        Description = "Change u",
                        ImageUrl = "https://i2-prod.manchestereveningnews.co.uk/incoming/article21411590.ece/ALTERNATES/s1200b/0_gettyimages-1207048163-170667a.jpg",
                    },
                        new BarberService // Id = 2
                    {
                        Name = "Cream & Shampoo",
                        Description = "Change u2",
                        ImageUrl = "https://img.freepik.com/premium-photo/master-barber-shop-washes-client-s-head-with-little-shampoo-water_283470-3579.jpg?w=2000",
                    },
                        new BarberService // Id = 3
                    {
                        Name = "Mustache Expert",
                        Description = "Change u3",
                        ImageUrl = "https://www.bodyexpert.online/wp-content/uploads/2022/04/greffe-de-barbe-01-1024x576.jpg",
                    },
                        new BarberService // Id = 4
                    {
                        Name = "Haircut Styler",
                        Description = "Change u4",
                        ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/styling-hair-by-professional-hairdresser-royalty-free-image-1626807625.jpg",
                    },
                        new BarberService // Id = 5
                    {
                        Name = "Razor For Beard",
                        Description = "Change u5",
                        ImageUrl = "https://media.istockphoto.com/id/622527180/photo/hipster-client-visiting-barber-shop.jpg?s=612x612&w=0&k=20&c=q5aEOfq8XccQfYbI-j9NjZjxO6J0av2JU47M9eJBfe0=",
                    },
                        new BarberService // Id = 6
                    {
                        Name = "Haircomb",
                        Description = "Change u6",
                        ImageUrl = "https://img.freepik.com/free-photo/barber-measuring-hair-with-comb_23-2148298332.jpg",
                    },
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}

