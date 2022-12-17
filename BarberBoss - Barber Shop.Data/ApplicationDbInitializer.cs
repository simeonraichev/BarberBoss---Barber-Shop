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
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<MyApplicationUser>>();
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
                    context.SaveChanges();
                }

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
                        Description = "Men's haircuts from the best barbers in the country. Cutting with the highest quality technologies and using high quality products.",
                        ImageUrl = "https://i2-prod.manchestereveningnews.co.uk/incoming/article21411590.ece/ALTERNATES/s1200b/0_gettyimages-1207048163-170667a.jpg",
                    },
                        new BarberService // Id = 2
                    {
                        Name = "Cream & Shampoo",
                        Description = "Your hair care from the best barbers with the best products in the industry.",
                        ImageUrl = "https://img.freepik.com/premium-photo/master-barber-shop-washes-client-s-head-with-little-shampoo-water_283470-3579.jpg?w=2000",
                    },
                        new BarberService // Id = 3
                    {
                        Name = "Mustache Expert",
                        Description = "Want to have a mustache but don't know how to style it? You are in the right place! Make an appointment and let us help you look better!",
                        ImageUrl = "https://www.bodyexpert.online/wp-content/uploads/2022/04/greffe-de-barbe-01-1024x576.jpg",
                    },
                        new BarberService // Id = 4
                    {
                        Name = "Haircut Styler",
                        Description = "Make a hairstyle with a fashionable style in the society! We expect you!",
                        ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/styling-hair-by-professional-hairdresser-royalty-free-image-1626807625.jpg",
                    },
                        new BarberService // Id = 5
                    {
                        Name = "Razor For Beard",
                        Description = " Shape your beard in the best possible way! Come to our barbershops and leave yourself in the hands of our professional barbers.",
                        ImageUrl = "https://media.istockphoto.com/id/622527180/photo/hipster-client-visiting-barber-shop.jpg?s=612x612&w=0&k=20&c=q5aEOfq8XccQfYbI-j9NjZjxO6J0av2JU47M9eJBfe0=",
                    },
                        new BarberService // Id = 6
                    {
                        Name = "Haircomb",
                        Description = "Do you want your hair to look so that everyone will like it? Come to our barbershops and we will take care of it!",
                        ImageUrl = "https://img.freepik.com/free-photo/barber-measuring-hair-with-comb_23-2148298332.jpg",
                    },
                    });
                    context.SaveChanges();

                }
                if (!context.Services.Any())
                {
                    context.Services.AddRange(new List<Service>()
                    {
                        //Shave & Haircut
                        new Service
                        {
                            Name = "Men's Haircut",
                            Description = "Men's haircuts from the best barbers in the country. Cutting with the highest quality technologies and using high quality products.",
                            BarberServiceId = 19
                        },
                        new Service
                        {
                            Name = "Crew Cut",
                            Description = "Haircut in a way that is very popular these days. Keep up with fashion!",
                            BarberServiceId = 19
                        },
                        new Service
                        {
                            Name = "Regular Cut",
                            Description = "Haircut in a simple way, with which you improve your vision radically!",
                            BarberServiceId = 19
                        },
                        new Service
                        {
                            Name = "Hair Color",
                            Description = "Dye your hair in every color you can think of. Keep up with fashion and come to our salons to change your look with the best quality hair products.",
                            BarberServiceId = 19
                        },

                        //Cream & Shampoo
                        new Service
                        {
                            Name = "Eyebrowс",
                            Description = "Got eyebrows you don't like? Come to our barber shops to change that. We are expecting you!",
                            BarberServiceId = 20
                        },
                         new Service
                        {
                             Name = "Skin Care",
                            Description = "Got skin growths you don't like? Come to our barbershops to take care of your skin hygiene! ",
                            BarberServiceId = 20
                        },
                          new Service
                        {
                              Name = "Men's Facials",
                            Description = "Facial cleaning by professionals in the field, welcome to improve your vision radically!",
                            BarberServiceId = 20
                        },
                           new Service
                        {
                               Name = "Facials - Teen",
                            Description = "Are you a teenager and have a lot of skin problems due to puberty? Come to our barbershops, where we will take care of you and your skin. We expect you!",
                            BarberServiceId = 20
                        },

                        //Mustache Expert
                        new Service
                        {
                            Name = "Combing",
                            Description = "Want to have a mustache but don't know how to style it? You are in the right place! Make an appointment and let us help you look better!",
                            BarberServiceId = 21
                        },
                         new Service
                        {
                            Name = "HairCondition",
                            Description = "Care for your mustache with the highest quality products and procedures! We expect you!",
                            BarberServiceId = 21
                        },
                          new Service
                        {
                            Name = "Wax",
                            Description = "Don't know how to shape your mustache in your dream way? Come to our barbershops and professionals will help you deal with it!",
                            BarberServiceId = 21
                        },

                        //Haircut Styler
                        new Service
                        {
                            Name = "Fade Haircuts",
                            Description = "Make a hairstyle with a fashionable style in the society! We expect you!",
                            BarberServiceId = 22
                        },
                         new Service
                        {
                            Name = "Taper Fade Cut",
                            Description = "Make a hairstyle with a fashionable style in the society! We expect you!",
                            BarberServiceId = 22
                        },
                          new Service
                        {
                            Name = "Cropped Cut",
                            Description = "Make a hairstyle with a fashionable style in the society! We expect you!",
                            BarberServiceId = 22
                        },
                           new Service
                        {
                            Name = "Comb Over Fade",
                            Description = "Make a hairstyle with a fashionable style in the society! We expect you!",
                            BarberServiceId = 22
                        },

                        //Razor For Beards
                        new Service
                        {
                            Name = "Beard Аlignment",
                            Description = "Shape your beard in the best possible way! Come to our barbershops and leave yourself in the hands of our professional barbers.",
                            BarberServiceId = 23
                        },
                        new Service
                        {
                            Name = "Beard Removal",
                            Description = "Don't like your beard? Come to our barbershops and we will take care of your wish! We expect you!",
                            BarberServiceId = 23
                        },
                        new Service
                        {
                            Name = "Beard Cosmetic",
                            Description = "Want your beard to feel and look good? Come to our barbershops and we will take care of it!",
                            BarberServiceId = 23
                        },

                        //Haircomb
                        new Service
                        {
                            Name = "Hair Styling",
                            Description = "Do you want your hair to look so that everyone will like it? Come to our barbershops and we will take care of it!",
                            BarberServiceId = 24
                        },
                        new Service
                        {
                            Name = "Hair&Dryer",
                            Description = "What more could you ask for? We expect you?",
                            BarberServiceId = 24
                        },
                        new Service
                        {
                            Name = "Premium",
                            Description = "Do you want your hair to be in perfect shape and with the best cosmetics? The only way is our package Hair&Beard&Cosmetic! Come to our barbershops! We expect you!",
                            BarberServiceId = 24
                        },
                    });
                    context.SaveChanges();
                }
                //BarberShopServices
                if (!context.BarberShopsServices.Any())
                {
                    context.BarberShopsServices.AddRange(new List<BarberShopsService>()
                    {
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded32a5654b-e3f7-426e-8352-c9a311d5bdd5",
                            ServiceId = 46,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded32a5654b-e3f7-426e-8352-c9a311d5bdd5",
                            ServiceId = 47,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded32a5654b-e3f7-426e-8352-c9a311d5bdd5",
                            ServiceId = 48,
                            Available = true
                        },

                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3af78164-6a3e-4b39-8673-9442cb32b23d",
                            ServiceId = 31,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3af78164-6a3e-4b39-8673-9442cb32b23d",
                            ServiceId = 32,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3af78164-6a3e-4b39-8673-9442cb32b23d",
                            ServiceId = 33,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3af78164-6a3e-4b39-8673-9442cb32b23d",
                            ServiceId = 34,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3fea1f9c-37e6-4980-86e6-666f90a78225",
                            ServiceId = 35,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3fea1f9c-37e6-4980-86e6-666f90a78225",
                            ServiceId = 36,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3fea1f9c-37e6-4980-86e6-666f90a78225",
                            ServiceId = 37,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seeded3fea1f9c-37e6-4980-86e6-666f90a78225",
                            ServiceId = 38,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededa2dd51a1-309a-434b-9ce9-b0cc82d8947e",
                            ServiceId = 49,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededa2dd51a1-309a-434b-9ce9-b0cc82d8947e",
                            ServiceId = 50,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededa2dd51a1-309a-434b-9ce9-b0cc82d8947e",
                            ServiceId = 51,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededea39ed9a-888f-46e0-8281-a0d2824013a2",
                            ServiceId = 31,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededea39ed9a-888f-46e0-8281-a0d2824013a2",
                            ServiceId = 32,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededea39ed9a-888f-46e0-8281-a0d2824013a2",
                            ServiceId = 33,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededea39ed9a-888f-46e0-8281-a0d2824013a2",
                            ServiceId = 34,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededf73edb4f-3a9c-4be6-bb9b-9430eba8e429",
                            ServiceId = 39,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededf73edb4f-3a9c-4be6-bb9b-9430eba8e429",
                            ServiceId = 40,
                            Available = true
                        },
                        new BarberShopsService()
                        {
                            BarberShopId = "seededf73edb4f-3a9c-4be6-bb9b-9430eba8e429",
                            ServiceId = 41,
                            Available = true
                        }
                    });
                    context.SaveChanges();
                }
                //Seeding Admin Account
                if (!context.Users.Any(a => a.FirstName == "Admin")) 
                {
                    var hasher = new PasswordHasher<MyApplicationUser>();
                    var adminUser = new MyApplicationUser();
                   
                    context.Users.AddRange(new List<MyApplicationUser>()
                    {
                        new MyApplicationUser()
                        {
                            Id = "seededAdminb8633e2d-a33b-45e6-8329-1958b3252bbd",
                            FirstName = "Admin",
                            LastName = "One",
                            UserName = "admin@gmail.com",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = Guid.NewGuid().ToString("D"),
                            PasswordHash = hasher.HashPassword(adminUser, "Password"),
                            LockoutEnabled = true,
                        }
                });
                    context.SaveChanges();
                }
                //Seeding Barber Account
                if (!context.Users.Any(a => a.FirstName == "Barber"))
                {
                    var hasher = new PasswordHasher<MyApplicationUser>();
                    var barberUser = new MyApplicationUser();

                    context.Users.AddRange(new List<MyApplicationUser>()
                    {
                        new MyApplicationUser()
                        {
                            Id = "seededBarberb8633e2d-a33b-45e6-8329-1958b3252bbd",
                            FirstName = "Barber",
                            LastName = "One",
                            UserName = "barber@gmail.com",
                            NormalizedUserName = "BARBER@GMAIL.COM",
                            Email = "barber@gmail.com",
                            EmailConfirmed = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = Guid.NewGuid().ToString("D"),
                            PasswordHash = hasher.HashPassword(barberUser, "Password"),
                            LockoutEnabled = true,
                        }
                });
                    context.SaveChanges();
                }
            }
        }
    }
}



