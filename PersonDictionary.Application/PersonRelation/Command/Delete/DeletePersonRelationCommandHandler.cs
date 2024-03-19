using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.PersonRelation.Command.Delete
{
    public class DeletePersonRelationCommandHandler(IUnitOfWork _uof) : IRequestHandler<DeletePersonRelationCommand, Unit>
    {
        public async Task<Unit> Handle(DeletePersonRelationCommand request, CancellationToken cancellationToken)
        {
            var personRelation = await _uof.PersonRelationRepository.GetAsync(x => x.PersonId == request.PersonId
                                                  && x.RelatedPersonId == request.RelatedPersonId
                                                  && x.PersonRelationTypeId == request.PersonRelationTypeId);

            ValidateOnExceptions(personRelation, request);

            personRelation.Delete();

            _uof.PersonRelationRepository.Update(personRelation);
            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void ValidateOnExceptions(Domain.Aggregates.Person.PersonRelation.PersonRelation personRelation, DeletePersonRelationCommand request)
        {
            if (personRelation == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFoundPersonRelation,
                            nameof(Domain.Aggregates.Person.PersonRelation.PersonRelation),
                            request.PersonId, request.RelatedPersonId, request.PersonRelationTypeId));
        }
    }
}
