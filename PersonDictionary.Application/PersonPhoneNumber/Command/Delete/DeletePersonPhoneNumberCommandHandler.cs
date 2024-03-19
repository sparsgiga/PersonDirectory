using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Delete
{
    public class DeletePersonPhoneNumberCommandHandler(IUnitOfWork _uof) : IRequestHandler<DeletePersonPhoneNumberCommand, Unit>
    {
        public async Task<Unit> Handle(DeletePersonPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetAllDetailsByIdAsync(request.PersonId);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.PersonId));

            person.DeleteNumber(request.PersonPhoneNumberId);

            _uof.PersonRepository.Update(person);

            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
