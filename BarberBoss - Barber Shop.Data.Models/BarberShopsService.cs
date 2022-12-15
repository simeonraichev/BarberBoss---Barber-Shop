using BarberBoss___Barber_Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class BarberShopsService : BaseDeletableModel<int>
    {
        public BarberShopsService()
        {
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        public string BarberShopId { get; set; }

        public virtual BarberShop BarberShop { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public bool? Available { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
