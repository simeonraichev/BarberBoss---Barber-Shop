using BarberBoss___Barber_Shop.Data.Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BarberBoss___Barber_Shop.Data.Models
{
    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
