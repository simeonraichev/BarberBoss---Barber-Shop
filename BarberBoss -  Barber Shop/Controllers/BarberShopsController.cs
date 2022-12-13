using BarberBoss___Barber_Shop.Services.Data.BarberServices;
using BarberBoss___Barber_Shop.Services.Data.BarberShops;
using BarberBoss___Barber_Shop.ViewModels.BarberServices;
using BarberBoss___Barber_Shop.ViewModels.BarberShops;
using BarberBoss___Barber_Shop.ViewModels.Common.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss____Barber_Shop.Controllers
{
    public class BarberShopsController : BaseController
    {
        private readonly IBarberShopsService barberShopsService;
        private readonly IBarberServicesService barberServicesService;

        public BarberShopsController(
            IBarberShopsService barberShopsService,
            IBarberServicesService barberServicesService)
        {
            this.barberShopsService = barberShopsService;
            this.barberServicesService = barberServicesService;
        }
         
        public async Task<IActionResult> Index(
            int? sortId, 
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            if (sortId != null)
            {
                var barberService = await this.barberServicesService
                    .GetByIdAsync<BarberServiceSimpleViewModel>(sortId.Value);
                if (barberService == null)
                {
                    return new StatusCodeResult(404);
                }

                this.ViewData["CategoryName"] = barberService.Name;
            }
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

            var barberShops = await this.barberShopsService
                .GetAllWithSortingFilteringAndPagingAsync<BarberShopViewModel>(
                    searchString, sortId, pageSize, pageIndex);
            var barberShopsList = barberShops.ToList();

            var count = await this.barberShopsService
                .GetCountForPaginationAsync(searchString, sortId);

            var viewModel = new BarberShopPaginatedListViewModel
            {
                BarberShops = new PaginatedList<BarberShopViewModel>(barberShopsList, count, pageIndex, pageSize),
            };
      
            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.barberShopsService.GetByIdAsync<BarberShopWithServicesViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }
    }
}
