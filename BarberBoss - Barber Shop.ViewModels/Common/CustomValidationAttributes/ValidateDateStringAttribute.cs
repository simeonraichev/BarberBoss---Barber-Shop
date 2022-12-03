using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.ViewModels.Common.CustomValidationAttributes
{
    public class ValidateDateStringAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var dateString = value as string;

            if (string.IsNullOrEmpty(dateString))
            {
                return false;
            }

            DateTime dt;
            bool parsed = DateTime.TryParseExact(
                            dateString,
                            "dd-MM-yyyy",
                            CultureInfo.InvariantCulture,
                            style: DateTimeStyles.AssumeUniversal,
                            result: out dt);
            if (!parsed)
            {
                return false;
            }

            if (dt < DateTime.UtcNow.Date)
            {
                return false;
            }

            return true;
        }
    }
}
