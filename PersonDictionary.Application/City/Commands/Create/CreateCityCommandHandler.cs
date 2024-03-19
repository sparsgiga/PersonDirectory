using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.City.Commands.Create
{
    public class CreateCityCommandHandler(IUnitOfWork _uof) : IRequestHandler<CreateCityCommand, int>
    {
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {

            if (await _uof.CityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower()))
                throw new AlreadyExistsException(string.Format(ExceptionMessageResource.RecordAlreadyExists, request.Name));

            var city = Domain.Aggregates.City.City.Create(request.Name.Trim());

            await _uof.CityRepository.AddAsync(city, cancellationToken);
            await _uof.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}
