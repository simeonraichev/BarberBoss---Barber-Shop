using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class Appointment
    {
        public DateTime DateTime { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual MyApplicationUser User { get; set; }

        [Required]
        public string BarberShopId { get; set; }

        public virtual BarberShop BarberShop { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual BarberShopService BarberShopService { get; set; }

        // The Salon can Confirm or Decline an appointment
        public bool? Confirmed { get; set; }

        public bool? IsSalonRatedByTheUser { get; set; }
    }
}
