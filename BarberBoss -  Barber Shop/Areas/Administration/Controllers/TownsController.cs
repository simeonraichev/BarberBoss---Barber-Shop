using BarberBoss___Barber_Shop.Services.Data.Towns;
using BarberBoss___Barber_Shop.ViewModels.Towns;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Areas.Administration.Controllers
{
    public class TownsController : AdministrationController
    {
        private readonly ITownService townService;

        public TownsController(ITownService townService)
        {
            this.townService = townService;
        }

        public IActionResult AddTown()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTown(TownInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.townService.AddAsync(input.Name);

            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new TownsListViewModel
            {
                Towns = await this.townService.GetAllAsync<TownViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTown(int id)
        {
            if (id <= 2)
            {
                return this.RedirectToAction("Index");
            }

            await this.townService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }


    }
}
