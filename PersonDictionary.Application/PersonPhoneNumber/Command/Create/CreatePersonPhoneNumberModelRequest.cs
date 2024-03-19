namespace PersonDirectory.Application.PersonPhoneNumber.Command.Create
{
    /// <summary>
    /// Represents a request to add a phone number to a specific person.
    /// </summary>
    public class CreatePersonPhoneNumberModelRequest
    {
        /// <summary>
        /// The unique identifier of the person to whom the phone number will be added.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The identifier of the phone number type (e.g., mobile, home, work).
        /// </summary>
        public int PhoneNumberTypeId { get; set; }

        /// <summary>
        /// The phone number to be added to the person.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
