using MediatR;
using PersonDirectory.Common.Application.Paging;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.City.Queries.Get
{
    public class GetCitiesQueryHandler(IUnitOfWork _uof) : IRequestHandler<GetCitiesQuery, PagedResult<CityModelResponse>>
    {
        public async Task<PagedResult<CityModelResponse>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var queryFiltered = CityFilter.Filter(_uof.CityRepository.Query(), request);

            return await BasePaging.CreatePagedItemsAsync<Domain.Aggregates.City.City, CityModelResponse>
                               (_uof.CityRepository, queryFiltered, request.PageNumber, request.PageSize);
        }
    }
}
