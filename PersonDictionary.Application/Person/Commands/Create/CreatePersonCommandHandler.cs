using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Commands.Create
{
    public class CreatePersonCommandHandler(IUnitOfWork _uof) : IRequestHandler<CreatePersonCommand, int>
    {
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var city = await _uof.CityRepository.GetByIdAsync(request.CityId);

            if (city == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.City.City), request.CityId));

            if (await _uof.PersonRepository.AnyAsync(x => x.PersonalNumber == request.PersonalNumber.Trim()))
                throw new AlreadyExistsException(string.Format(ExceptionMessageResource.RecordAlreadyExists, request.PersonalNumber));

            var person = Domain.Aggregates.Person.Person.Create(request.Name,
                                                                request.LastName,
                                                                request.PersonalNumber,
                                                                request.BirthDate,
                                                                request.Gender,
                                                                request.CityId);

            await _uof.PersonRepository.AddAsync(person, cancellationToken);
            var personId = await _uof.SaveChangesAsync(cancellationToken);

            return personId;
        }
    }
}
