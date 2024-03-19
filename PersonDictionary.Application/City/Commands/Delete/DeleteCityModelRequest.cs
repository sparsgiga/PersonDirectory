namespace PersonDirectory.Application.City.Commands.Delete
{
    /// <summary>
    /// Represents a request to delete an existing city.
    /// </summary>
    public class DeleteCityModelRequest
    {
        /// <summary>
        /// Gets or sets the identifier of the city to be deleted.
        /// </summary>
        public int Id { get; set; }
    }
}
