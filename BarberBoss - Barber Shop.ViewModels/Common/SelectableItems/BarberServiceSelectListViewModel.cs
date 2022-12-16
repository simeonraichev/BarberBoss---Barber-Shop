using BarberBoss____Barber_Shop.Services.Mapping;
using BarberBoss___Barber_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Common.SelectableItems
{
    public class BarberServiceSelectListViewModel : IMapFrom<BarberService>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
