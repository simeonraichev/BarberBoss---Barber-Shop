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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> appointment)
        {
            appointment
                .HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId);

            appointment
                .HasOne(a => a.BarberShop)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.BarberShopId);

            appointment
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId);
            //appointment
            //    .HasOne(a => a.BarberShopService)
            //    .WithMany(ss => ss.Appointments)
            //    .HasForeignKey(a => a.BarberShopId);

        }
    }
}
