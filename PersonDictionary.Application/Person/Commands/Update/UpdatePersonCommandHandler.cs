using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Commands.Update
{
    public class UpdatePersonCommandHandler(IUnitOfWork _uof) : IRequestHandler<UpdatePersonCommand>
    {
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            if (!await _uof.CityRepository.AnyAsync(x => x.Id == request.CityId))
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.City.City), request.CityId));

            var person = await _uof.PersonRepository.GetByIdAsync(request.Id);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.Id));

            person.Update(request.Name,
                          request.LastName,
                          request.PersonalNumber,
                          request.BirthDate,
                          request.Gender,
                          request.CityId);
            _uof.PersonRepository.Update(person);
            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
