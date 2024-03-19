using FluentValidation;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Delete
{
    public class DeletePersonPhoneNumberCommandValidator : AbstractValidator<DeletePersonPhoneNumberCommand>
    {
        public DeletePersonPhoneNumberCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.PersonPhoneNumberId).NotEmpty();
        }
    }
}
