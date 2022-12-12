using BarberBoss___Barber_Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class Appointment : BaseDeletableModel<string>
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

        public virtual BarberShopsService BarberShopService { get; set; }

        // The BarberShop can Confirm or Decline an appointment
        public bool? Confirmed { get; set; }

        public bool? IsBarberShopRatedByTheUser { get; set; }
    }
}
