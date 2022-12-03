using BarberBoss___Barber_Shop.ViewModels.Common.CustomValidationAttributes;
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
        [ValidateDateString(ErrorMessage = "Please select a valid DATE from the datepicker calendar on the left.")]
        public string Date { get; set; }

        [Required]
        [ValidateTimeString(ErrorMessage = "Please select a valid TIME from the datepicker calendar on the left.")]
        public string Time { get; set; }
    }
}
