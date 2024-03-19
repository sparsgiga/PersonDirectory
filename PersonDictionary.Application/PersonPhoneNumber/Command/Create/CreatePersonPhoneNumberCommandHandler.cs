using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Create
{
    public class CreatePersonPhoneNumberCommandHandler(IUnitOfWork _uof) : IRequestHandler<CreatePersonPhoneNumberCommand, Unit>
    {
        public async Task<Unit> Handle(CreatePersonPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetByIdAsync(request.PersonId);

            await ValidateOnException(person, request);

            person.AddPhoneNumber(Domain.Aggregates.Person.PersonPhoneNumber.Create(request.PhoneNumber, request.PhoneNumberTypeId));

            _uof.PersonRepository.Update(person);
            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task ValidateOnException(Domain.Aggregates.Person.Person person, CreatePersonPhoneNumberCommand request)
        {
            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.PersonId));

            if (!await _uof.PhoneNumberTypeRepository.AnyAsync(x => x.Id == request.PhoneNumberTypeId))
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.PhoneNumberType.PhoneNumberType), request.PhoneNumberTypeId));
        }
    }
}
