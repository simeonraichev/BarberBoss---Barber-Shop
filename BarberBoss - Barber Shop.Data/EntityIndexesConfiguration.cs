using BarberBoss___Barber_Shop.Data.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data
{
    internal static class EntityIndexesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // IDeletableEntity.IsDeleted index
            var deletableEntityTypes = modelBuilder.Model
                .GetEntityTypes()
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                modelBuilder.Entity(deletableEntityType.ClrType).HasIndex(nameof(IDeletableEntity.IsDeleted));
            }
        }
    }
}
