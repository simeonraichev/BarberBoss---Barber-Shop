using BarberBoss___Barber_Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.Salons = new HashSet<BarberShopsService>();
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<BarberShopsService> Salons { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
