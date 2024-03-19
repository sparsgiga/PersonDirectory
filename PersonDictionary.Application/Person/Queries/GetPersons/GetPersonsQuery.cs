using MediatR;
using PersonDirectory.Common.Application.Paging;
using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Queries.GetPersons
{
    public class GetPersonsQuery : IRequest<PagedResult<GetPersonsModelResponse>>
    {
        public string FilterQuery { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public int CityId { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}