using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.City.Commands.Delete
{
    public class DeleteCityCommandHandler(IUnitOfWork _uof) : IRequestHandler<DeleteCityCommand>
    {
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _uof.CityRepository.GetByIdAsync(request.Id);

            if (city == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.City.City), request.Id));
            city.Delete();
            _uof.CityRepository.Update(city);

            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
