namespace PersonDirectory.Application.Person.Commands.Delete
{
    /// <summary>
    /// Represents a request to delete a person identified by their unique identifier.
    /// </summary>
    public class DeletePersonModelRequest
    {
        /// <summary>
        /// The unique identifier of the person to be deleted.
        /// </summary>
        public int Id { get; set; }
    }
}
