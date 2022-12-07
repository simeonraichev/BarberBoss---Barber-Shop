using BarberBoss___Barber_Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class BarberShop : BaseDeletableModel<string>
    {
        public BarberShop()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Services = new HashSet<BarberShopsService>();
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string OwnerId { get; set; }

        public virtual MyApplicationUser Owner { get; set; }
        
        public int BarberServiceId { get; set; }

        public virtual BarberService BarberService { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        [Required]
        [MaxLength(15)]
        public string Address { get; set; }

        public double Rating { get; set; }

        public int RatersCount { get; set; }

        public virtual ICollection<BarberShopsService> Services { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
