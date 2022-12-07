using BarberBoss___Barber_Shop.ViewModels.Common.CustomValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.BarberServices
{
    public class BarberServiceInputModel
    {
        [Required]
        [StringLength(
           40,
           ErrorMessage = "Name must be between 2 and 40 characters.",
           MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            700,
            ErrorMessage = "Description must be between 50 and 700 characters.",
            MinimumLength = 50)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = "Please select a JPG, JPEG or PNG image smaller than 1MB.")]
        public IFormFile Image { get; set; }
    }
}
