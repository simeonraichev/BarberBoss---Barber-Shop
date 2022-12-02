using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.ViewModels.BarberShops;
using BarberBoss___Barber_Shop.ViewModels.Common.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Controllers
{
    public class BarberShopsController : Controller
    {
        private readonly IBarberShopsService salonsService;

        public BarberShopsController(
            IBarberShopsService salonsService)
        {
            this.salonsService = salonsService;
        }

        public async Task<IActionResult> Index(
            int? sortId, // categoryId
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            this.ViewData["CurrentSort"] = sortId;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.ViewData["CurrentFilter"] = searchString;

            int pageSize = 8;
            var pageIndex = pageNumber ?? 1;

            var salons = await this.salonsService
                .GetAllWithSortingFilteringAndPagingAsync<BarberShopViewModel>(
                    searchString, sortId, pageSize, pageIndex);
            var salonsList = salons.ToList();

            var count = await this.salonsService
                .GetCountForPaginationAsync(searchString, sortId);

            var viewModel = new BarberShopPaginatedListViewModel
            {
                BarberShops = new PaginatedList<BarberShopViewModel>(salonsList, count, pageIndex, pageSize),
            };
      
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.salonsService.GetByIdAsync<BarberShopWithServicesViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }
    }
}
