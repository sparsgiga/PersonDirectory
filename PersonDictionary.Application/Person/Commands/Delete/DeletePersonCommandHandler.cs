using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Commands.Delete
{
    public class DeletePersonCommandHandler(IUnitOfWork _uof) : IRequestHandler<DeletePersonCommand>
    {
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetByIdAsync(request.Id);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.Person.Person), request.Id));

            person.Delete();

            _uof.PersonRepository.Update(person);
            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
