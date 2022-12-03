using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Common.CustomValidationAttributes
{
    public class ValidateTimeStringAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var timeString = value as string;

            if (string.IsNullOrEmpty(timeString))
            {
                return false;
            }

            bool parsed = DateTime.TryParseExact(
                            timeString,
                            "h:mmtt",
                            CultureInfo.InvariantCulture,
                            style: DateTimeStyles.AssumeUniversal,
                            result: out _);
            if (!parsed)
            {
                return false;
            }

            return true;
        }
    }
}
