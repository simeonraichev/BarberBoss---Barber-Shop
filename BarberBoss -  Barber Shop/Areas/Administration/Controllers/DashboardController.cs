using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
