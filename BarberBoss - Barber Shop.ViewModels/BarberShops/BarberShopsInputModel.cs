using BarberBoss___Barber_Shop.ViewModels.Common.CustomValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.BarberShops
{
    public class BarberShopsInputModel
    {
        [Required]
        [StringLength(
            40,
            ErrorMessage = "Name must be between 2 and 40 characters.",
            MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(
            5,
            ErrorMessage = "Address must be between 5 and 100 characters.",
            MinimumLength = 100)]
        public string Address { get; set; }

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = "Please select a JPG, JPEG or PNG image smaller than 1MB.")]
        public IFormFile Image { get; set; }
    }
}
