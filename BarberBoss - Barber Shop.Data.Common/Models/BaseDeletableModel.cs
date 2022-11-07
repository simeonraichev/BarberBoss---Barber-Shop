using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data.Common.Models
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
