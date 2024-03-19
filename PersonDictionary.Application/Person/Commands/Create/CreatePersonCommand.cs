using MediatR;
using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Commands.Create
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public int CityId { get; set; }
    }
}
