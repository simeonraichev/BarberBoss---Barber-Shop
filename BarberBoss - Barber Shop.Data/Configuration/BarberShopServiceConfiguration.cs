using BarberBoss___Barber_Shop.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Configuration
{
    public class BarberShopServiceConfiguration
    {
        public void Configure(EntityTypeBuilder<BarberShopsService> salonService)
        {
            salonService.HasKey(bs => new { bs.BarberShopId, bs.ServiceId });
        }
    }
}
