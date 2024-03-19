using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Update
{
    public class UpdatePersonPhoneNumberCommandHandler(IUnitOfWork _uof) : IRequestHandler<UpdatePersonPhoneNumberCommand, Unit>
    {
        public async Task<Unit> Handle(UpdatePersonPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetAllDetailsByIdAsync(request.PersonId);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.PersonId));

            if (!await _uof.PhoneNumberTypeRepository.AnyAsync(x => x.Id == request.PhoneNumberTypeId))
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.PhoneNumberType.PhoneNumberType), request.PhoneNumberTypeId));

            person.UpdateNumber(request.PersonPhoneNumberId, request.PhoneNumberTypeId, request.Number);

            _uof.PersonRepository.Update(person);

            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
