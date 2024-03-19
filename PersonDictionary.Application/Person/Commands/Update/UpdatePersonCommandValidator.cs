using FluentValidation;
using PersonDirectory.Application.Person.Helper;
using PersonDirectory.Application.Resources;

namespace PersonDirectory.Application.Person.Commands.Update
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();

            RuleFor(x => x.Gender).NotEmpty().IsInEnum();

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(2, 50)
                .Must(ValidationHelper.ValidateForMixedLanguages)
                .WithMessage(x => string.Format(ValidationResource.MixedLanguage, nameof(x.Name)));

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(2, 50)
                .Must(ValidationHelper.ValidateForMixedLanguages)
                .WithMessage(x => string.Format(ValidationResource.MixedLanguage, nameof(x.LastName)));

            RuleFor(x => x.PersonalNumber)
                .NotEmpty()
                .Length(11)
                .Matches("^[0-9]*$");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(ValidationHelper.PersonAgeValidation)
                .WithMessage(ValidationResource.PersonAge);
        }
    }
}
