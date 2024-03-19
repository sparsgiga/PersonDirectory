using MediatR;

namespace PersonDirectory.Application.Person.Queries.GetPerson
{
    public class GetPersonQuery : IRequest<GetPersonModelResponse>
    {
        public int Id { get; set; }
    }
}
