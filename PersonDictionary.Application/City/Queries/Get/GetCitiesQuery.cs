using MediatR;
using PersonDirectory.Common.Application.Paging;


namespace PersonDirectory.Application.City.Queries.Get
{
    public class GetCitiesQuery : IRequest<PagedResult<CityModelResponse>>
    {
        public string FilterQuery { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

    }
}
