using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Barber.Controllers
{
    public class DashboardController : BarberBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
