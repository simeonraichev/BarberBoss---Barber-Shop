using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Towns
{
    public class TownInputModel
    {
        [Required]
        [StringLength(
            40,
            ErrorMessage = "Name must be between 2 and 40 characters.",
            MinimumLength = 1)]
        public string Name { get; set; }
    }
}
