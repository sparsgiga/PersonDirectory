using MediatR;

namespace PersonDirectory.Application.Person.Commands.DeletePhoto
{
    public class DeletePersonPhotoCommand : IRequest<Unit>
    {
        public int PersonId { get; set; }
    }
}
