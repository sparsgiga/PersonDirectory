using MediatR;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Delete
{
    public class DeletePersonPhoneNumberCommand : IRequest<Unit>
    {
        public int PersonId { get; set; }
        public int PersonPhoneNumberId { get; set; }
    }
}
