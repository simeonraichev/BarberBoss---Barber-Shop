using BarberBoss____Barber_Shop.Services.Mapping;
using BarberBoss___Barber_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.BarberShops
{
    public class BarberShopWithServicesViewModel : IMapFrom<BarberShop>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string BarberServiceName { get; set; }

        public string TownName { get; set; }

        public string Address { get; set; }

        public double Rating { get; set; }

        public int RatersCount { get; set; }

        public virtual ICollection<BarberShopServiceViewModel> Services { get; set; }
    }
}
