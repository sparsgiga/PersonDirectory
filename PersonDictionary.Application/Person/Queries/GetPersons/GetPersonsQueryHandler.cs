using MediatR;
using PersonDirectory.Common.Application.Paging;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Queries.GetPersons
{
    public class GetPersonsQueryHandler(IUnitOfWork _uof) : IRequestHandler<GetPersonsQuery, PagedResult<GetPersonsModelResponse>>
    {
        public async Task<PagedResult<GetPersonsModelResponse>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {

            var queryFiltered = PersonsFilter.Filter(_uof.PersonRepository.Query(), request);

            return await BasePaging.CreatePagedItemsAsync<Domain.Aggregates.Person.Person, GetPersonsModelResponse>
                               (_uof.PersonRepository, queryFiltered, request.PageNumber, request.PageSize);
        }
    }
}
