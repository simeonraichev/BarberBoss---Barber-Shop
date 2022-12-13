using BarberBoss____Barber_Shop.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Barber.Controllers
{
    [Authorize(Roles = "Barber")]
    [Area("Barber")]
    public class BarberBaseController : BaseController
    {
    }
}
