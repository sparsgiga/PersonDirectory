using FluentValidation;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Create
{
    public class CreatePersonPhoneNumberCommandValidator : AbstractValidator<CreatePersonPhoneNumberCommand>
    {
        public CreatePersonPhoneNumberCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).Length(4, 50).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.PhoneNumberTypeId).NotEmpty();
        }
    }
}
