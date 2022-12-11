using BarberBoss____Barber_Shop.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    [Authorize("Administrator")]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
