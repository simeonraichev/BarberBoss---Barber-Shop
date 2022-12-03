using BarberBoss___Barber_Shop.Common;
using BarberBoss___Barber_Shop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BarberBoss____Barber_Shop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public async Task<IActionResult> Index()
        {
            
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [Route("/Home/Error/404")]
        public IActionResult Error404()
        {
            return this.View();
        }

        [Route("/Home/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            // Could handle different codes here
            // or just return the default error view
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}