namespace PersonDirectory.Application.Person.Queries.GetPerson
{
    /// <summary>
    /// Represents a request to retrieve detailed information about a specific person identified by their unique identifier.
    /// </summary>
    public class GetPersonModelRequest
    {
        /// <summary>
        /// The unique identifier of the person whose details are being requested.
        /// </summary>
        public int Id { get; set; }
    }
}
