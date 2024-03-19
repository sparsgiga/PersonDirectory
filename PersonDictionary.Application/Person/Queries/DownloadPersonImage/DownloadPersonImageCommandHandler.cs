using MediatR;
using PersonDirectory.Application.Services;

namespace PersonDirectory.Application.Person.Queries.DownloadPersonImage
{
    public class DownloadPersonImageCommandHandler(IFileManagerService _fileManagerService) : IRequestHandler<DownloadPersonImageCommand, byte[]>
    {
        public async Task<byte[]> Handle(DownloadPersonImageCommand request, CancellationToken cancellationToken)
        {
            var photo = await _fileManagerService.DownloadFileAsync(request.PhotoUrl);

            return photo;
        }
    }
}
