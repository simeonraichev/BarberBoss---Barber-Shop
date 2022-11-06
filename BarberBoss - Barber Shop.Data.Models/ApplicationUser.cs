using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace BarberBoss___Barber_Shop.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
    }
}