using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.DateTimeParser
{
    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date, string time);
    }
}
