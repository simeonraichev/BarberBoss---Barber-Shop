using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class Service
    {
        public Service()
        {
            this.Salons = new HashSet<BarberShopService>();
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<BarberShopService> Salons { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
