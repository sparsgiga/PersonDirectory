using FluentValidation;

namespace PersonDirectory.Application.Person.Commands.UploadPhoto
{
    public class UploadPersonPhotoCommandValidator : AbstractValidator<UploadPersonPhotoCommand>
    {
        public UploadPersonPhotoCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.Photo).NotEmpty();
        }
    }
}
