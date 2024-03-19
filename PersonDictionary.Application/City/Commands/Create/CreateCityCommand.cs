using MediatR;

namespace PersonDirectory.Application.City.Commands.Create
{
    public class CreateCityCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
