using FluentValidation;

namespace PersonDirectory.Application.Person.Commands.DeletePhoto
{
    public class DeletePersonPhotoCommandValidator : AbstractValidator<DeletePersonPhotoCommand>
    {
        public DeletePersonPhotoCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
        }
    }
}
