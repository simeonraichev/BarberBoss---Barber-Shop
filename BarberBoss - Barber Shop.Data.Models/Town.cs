using BarberBoss___Barber_Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class Town : BaseDeletableModel<int>
    {
        public Town()
        {
            this.BarberShops = new HashSet<BarberShop>();
        }

        [Required]
        [MaxLength(50)]
        //TODO: Extract the constants in global class
        public string Name { get; set; }

        public virtual ICollection<BarberShop> BarberShops { get; set; }
    }
}
