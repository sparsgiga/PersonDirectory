namespace PersonDirectory.Application.PersonPhoneNumber.Command.Update
{
    /// <summary>
    /// Represents a request to update the details of a phone number associated with a person.
    /// </summary>
    public class UpdatePersonPhoneNumberModelRequest
    {
        /// <summary>
        /// The unique identifier of the person whose phone number is to be updated.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The unique identifier of the phone number to be updated.
        /// </summary>
        public int PersonPhoneNumberId { get; set; }

        /// <summary>
        /// The identifier of the new phone number type (e.g., mobile, home).
        /// </summary>
        public int PhoneNumberTypeId { get; set; }

        /// <summary>
        /// The new phone number to be associated with the person.
        /// </summary>
        public string Number { get; set; }
    }
}
