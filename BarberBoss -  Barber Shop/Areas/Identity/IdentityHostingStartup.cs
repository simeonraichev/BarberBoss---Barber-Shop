using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BarberBoss____Barber_Shop.Web.Areas.Identity.IdentityHostingStartup))]
namespace BarberBoss____Barber_Shop.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
