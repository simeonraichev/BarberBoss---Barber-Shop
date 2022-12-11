using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BarberBoss___Barber_Shop.Data.Common.Models;

using Microsoft.AspNetCore.Identity;


namespace BarberBoss___Barber_Shop.Data.Models
{
    public class MyApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public MyApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Appointments = new HashSet<Appointment>();
            this.BarberShops = new HashSet<BarberShop>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<BarberShop> BarberShops { get; set; }
    }
}