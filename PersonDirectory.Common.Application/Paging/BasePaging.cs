using Mapster;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Common.Application.Paging
{
    public abstract class BasePaging
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value <= 0) ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value <= 0) ? 10 : value;
        }

        public int SkipCount => (PageNumber - 1) * PageSize;

        public static async Task<PagedResult<TResponse>> CreatePagedItemsAsync<T, TResponse>(
            IRepository<T> repository,
            IQueryable<T> query,
            int pageNumber,
            int pageSize)
            where T : class
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;

            var totalItemCount = await repository.CountAsync(query);
            var items = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectToType<TResponse>()
                .ToList();

            return new PagedResult<TResponse>
            {
                Items = items,
                TotalItemCount = totalItemCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize)
            };
        }
    }
}
