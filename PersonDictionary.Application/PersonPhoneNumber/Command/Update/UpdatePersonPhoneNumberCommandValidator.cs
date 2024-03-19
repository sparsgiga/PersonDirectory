using FluentValidation;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Update
{
    public class UpdatePersonPhoneNumberCommandValidator : AbstractValidator<UpdatePersonPhoneNumberCommand>
    {
        public UpdatePersonPhoneNumberCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.PersonPhoneNumberId).NotEmpty();
            RuleFor(x => x.PhoneNumberTypeId).NotEmpty();
            RuleFor(x => x.Number).Length(4, 50).NotEmpty();
        }
    }
}
