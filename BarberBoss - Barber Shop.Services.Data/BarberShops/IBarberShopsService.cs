using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss___Barber_Shop.Services.Data.BarberShops
{
    public interface IBarberShopsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync(string searchString, int? sortId);

        Task<IEnumerable<string>> GetAllIdsByBarberServiceAsync(int barberServiceId);

        Task<T> GetByIdAsync<T>(string id);

        Task<string> AddAsync(string name, int categoryId, int cityId, string address, string imageUrl);

        Task DeleteAsync(string id);

        Task RateSalonAsync(string id, int rateValue);
    }
}
