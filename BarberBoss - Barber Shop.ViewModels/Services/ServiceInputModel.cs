using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Services
{
    public class ServiceInputModel
    {
        [Required]
        [StringLength(
            40,
            ErrorMessage = "Name must be between 2 and 40 characters.",
            MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int BarberServiceId { get; set; }

        [Required]
        [StringLength(
            650,
            ErrorMessage = "Description must be between 40 and 650 characters.",
            MinimumLength = 40)]
        public string Description { get; set; }
    }
}
