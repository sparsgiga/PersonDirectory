using MediatR;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Create
{
    public class CreatePersonPhoneNumberCommand : IRequest<Unit>
    {
        public int PersonId { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
