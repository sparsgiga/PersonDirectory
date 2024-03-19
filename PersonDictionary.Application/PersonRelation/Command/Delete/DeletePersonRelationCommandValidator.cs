using FluentValidation;

namespace PersonDirectory.Application.PersonRelation.Command.Delete
{
    public class DeletePersonRelationCommandValidator : AbstractValidator<DeletePersonRelationCommand>
    {
        public DeletePersonRelationCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.RelatedPersonId).NotEqual(x => x.PersonId).NotEmpty();
            RuleFor(x => x.PersonRelationTypeId).NotEmpty();
        }
    }
}
