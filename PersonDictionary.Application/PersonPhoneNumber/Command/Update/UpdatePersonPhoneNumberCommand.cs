using MediatR;

namespace PersonDirectory.Application.PersonPhoneNumber.Command.Update
{
    public class UpdatePersonPhoneNumberCommand : IRequest<Unit>
    {
        public int PersonId { get; set; }
        public int PersonPhoneNumberId { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public string Number { get; set; }
    }
}
