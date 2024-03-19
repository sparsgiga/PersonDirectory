using FluentValidation;

namespace PersonDirectory.Application.City.Commands.Create
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
