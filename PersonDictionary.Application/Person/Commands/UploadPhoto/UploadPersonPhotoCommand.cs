using MediatR;
using Microsoft.AspNetCore.Http;

namespace PersonDirectory.Application.Person.Commands.UploadPhoto
{
    public class UploadPersonPhotoCommand : IRequest<Unit>
    {
        public int PersonId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
