using FluentValidation;

namespace PersonDirectory.Application.Person.Queries.DownloadPersonImage
{
    public class DownloadPersonImageCommandValidator : AbstractValidator<DownloadPersonImageCommand>
    {
        public DownloadPersonImageCommandValidator()
        {
            RuleFor(x => x.PhotoUrl).NotEmpty();
        }
    }
}
