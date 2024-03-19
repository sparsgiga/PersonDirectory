using MediatR;
using PersonDirectory.Application.Resources;
using PersonDirectory.Application.Services;
using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Application.Person.Commands.DeletePhoto
{
    public class DeletePersonPhotoCommandHandler(IUnitOfWork _uof, IFileManagerService _fileManager) : IRequestHandler<DeletePersonPhotoCommand>
    {
        public async Task<Unit> Handle(DeletePersonPhotoCommand request, CancellationToken cancellationToken)
        {
            var person = await _uof.PersonRepository.GetByIdAsync(request.PersonId);

            if (person == null)
                throw new NotFoundException(string.Format(ExceptionMessageResource.NotFound,
                                            nameof(Domain.Aggregates.Person.Person), request.PersonId));

            if (!string.IsNullOrEmpty(person.Photo))
            {
                await _fileManager.DeleteFileAsync(person.Photo);
                person.DeletePhoto();
                _uof.PersonRepository.Update(person);

                await _uof.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }

}
