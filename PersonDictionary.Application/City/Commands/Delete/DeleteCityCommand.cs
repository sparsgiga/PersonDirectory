using MediatR;

namespace PersonDirectory.Application.City.Commands.Delete
{
    public class DeleteCityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
