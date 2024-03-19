namespace PersonDirectory.Application.PersonPhoneNumber.Command.Delete
{
    /// <summary>
    /// Represents a request to delete a specific phone number associated with a person.
    /// </summary>
    public class DeletePersonPhoneNumberModelRequest
    {
        /// <summary>
        /// The unique identifier of the person from whom the phone number will be deleted.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The unique identifier of the phone number to be deleted.
        /// </summary>
        public int PersonPhoneNumberId { get; set; }
    }
}
