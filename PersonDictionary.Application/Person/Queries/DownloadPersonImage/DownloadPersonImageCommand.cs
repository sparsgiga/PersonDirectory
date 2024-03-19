using MediatR;

namespace PersonDirectory.Application.Person.Queries.DownloadPersonImage
{
    public class DownloadPersonImageCommand : IRequest<byte[]>
    {
        public string PhotoUrl { get; set; }
    }
}
