using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Appointments
{
    public class AppointmentsInputModel
    {
        [Required]
        public string BarberShopId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        //TODO: Validate
    }
}
