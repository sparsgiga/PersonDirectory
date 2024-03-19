using MediatR;

namespace PersonDirectory.Application.Person.Commands.Delete
{
    public class DeletePersonCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
