﻿//using BarberBoss___Barber_Shop.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BarberBoss___Barber_Shop.Data.Seeding.CustomSeeding
//{
//    public class TownsSeeder : ISeeder
//    {
//        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
//        {
//            if (dbContext.Towns.Any())
//            {
//                return;
//            }

//            var towns = new Town[]
//                {
//                    new Town // Id = 1
//                    {
//                        Name = "Sofia",
//                    },
//                    new Town // Id = 2
//                    {
//                        Name = "Plovdiv",
//                    },
//                };

//            // Ordered
//            foreach (var city in towns)
//            {
//                await dbContext.AddAsync(city);
//                await dbContext.SaveChangesAsync();
//            }
//        }
//    }
//}
