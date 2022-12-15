using BarberBoss____Barber_Shop.Services.Mapping;
using BarberBoss___Barber_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.BarberShopsServices
{
    public class BarberShopsServiceSimpleViewModel : IMapFrom<BarberShopsService>
    {
        public string BarberShopId { get; set; }

        public int ServiceId { get; set; }

        public bool Available { get; set; }
    }
}
