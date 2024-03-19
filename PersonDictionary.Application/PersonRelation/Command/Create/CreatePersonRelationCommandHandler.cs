using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.PersonRelation.Command.Create
{
    public class CreatePersonRelationCommandHandler(IUnitOfWork _uof) : IRequestHandler<CreatePersonRelationCommand, int>
    {
        public async Task<int> Handle(CreatePersonRelationCommand request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetByIdAsync(request.PersonId);

            await ValidateOnExceptions(person, request);

            var personRelation = Domain.Aggregates.Person.PersonRelation.PersonRelation
                     .Create(request.PersonId, request.RelatedPersonId, request.PersonRelationTypeId);

            _uof.PersonRelationRepository.Update(personRelation);
            await _uof.SaveChangesAsync(cancellationToken);

            return personRelation.Id;
        }

        private async Task ValidateOnExceptions(Domain.Aggregates.Person.Person person, CreatePersonRelationCommand request)
        {
            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.PersonId));

            if (!await _uof.PersonRepository.AnyAsync(x => x.Id == request.RelatedPersonId))
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(Domain.Aggregates.Person.Person), request.RelatedPersonId));

            if (!await _uof.PersonRelationTypeRepository.AnyAsync(x => x.Id == request.PersonRelationTypeId))
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                            nameof(PersonRelationType), request.PersonRelationTypeId));

            if (await _uof.PersonRelationRepository.AnyAsync(x => x.PersonId == request.PersonId
                                                  && x.RelatedPersonId == request.RelatedPersonId
                                                  && x.PersonRelationTypeId == request.PersonRelationTypeId))
                throw new AlreadyExistsException(string.Format(ExceptionMessageResource.RecordAlreadyExists,
                    nameof(Domain.Aggregates.Person.PersonRelation.PersonRelation)));
        }
    }
}
