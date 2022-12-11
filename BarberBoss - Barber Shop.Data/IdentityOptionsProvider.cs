using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Data
{
    public static class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireLowercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.User.RequireUniqueEmail = false;
            options.Password.RequireUppercase = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireNonAlphanumeric = false;

        }
    }
}
