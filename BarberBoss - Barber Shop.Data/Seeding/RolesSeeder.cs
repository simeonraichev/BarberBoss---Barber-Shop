using BarberBoss___Barber_Shop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Seeding
{
    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, "Administrator");
            await SeedRoleAsync(roleManager, "Barber");
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var roleByName = await roleManager.FindByNameAsync(roleName);
            if (roleByName == null)
            {
                var finalResult = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!finalResult.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, finalResult.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
