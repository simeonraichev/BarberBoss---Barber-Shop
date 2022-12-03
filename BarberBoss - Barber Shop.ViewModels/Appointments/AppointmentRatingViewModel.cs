using BarberBoss____Barber_Shop.Services.Mapping;
using BarberBoss___Barber_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Appointments
{
    public class AppointmentRatingViewModel : IMapFrom<Appointment>
    {
        public string Id { get; set; }

        public string BarberShopId { get; set; }

        public string BarberShopName { get; set; }

        public string BarberShopTownName { get; set; }

        public string BarberShopAddress { get; set; }

        public string BarberShopImageUrl { get; set; }

        public bool? IsBarberShopRatedByTheUser { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Please choose a valid number of stars from 1 to 5.")]
        public int RateValue { get; set; }
    }
}
