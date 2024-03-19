using MediatR;

namespace PersonDirectory.Application.City.Commands.Update
{
    public class UpdateCityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
