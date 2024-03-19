using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Application.Services;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Commands.UploadPhoto
{
    public class UploadPersonPhotoCommandHandler(IUnitOfWork _uof, IFileManagerService _fileManager) : IRequestHandler<UploadPersonPhotoCommand>
    {
        public async Task<Unit> Handle(UploadPersonPhotoCommand request, CancellationToken cancellationToken)
        {
            var newPhotoUrl = string.Empty;
            var person = await _uof.PersonRepository.GetByIdAsync(request.PersonId);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.Person.Person), request.PersonId));
            newPhotoUrl = !string.IsNullOrEmpty(person.Photo)
                          ? (newPhotoUrl = await _fileManager.ReplaceFileAsync(request.Photo, person.Photo))
                          : newPhotoUrl = await _fileManager.UploadFileAsync(request.Photo);

            person.UpdatePhotoUrl(newPhotoUrl);

            _uof.PersonRepository.Update(person);
            await _uof.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
