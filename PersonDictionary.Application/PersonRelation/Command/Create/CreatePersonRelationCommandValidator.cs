using FluentValidation;

namespace PersonDirectory.Application.PersonRelation.Command.Create
{
    public class CreatePersonRelationCommandValidator : AbstractValidator<CreatePersonRelationCommand>
    {
        public CreatePersonRelationCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.RelatedPersonId).NotEqual(x => x.PersonId).NotEmpty();
            RuleFor(x => x.PersonRelationTypeId).NotEmpty();
        }
    }
}
