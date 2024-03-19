namespace PersonDirectory.Application.City.Commands.Update
{
    /// <summary>
    /// Represents a request to update the information of an existing city identified by its Id.
    /// </summary>
    public class UpdateCityModelRequest
    {
        /// <summary>
        /// The unique identifier of the city to be updated.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The new name for the city.
        /// </summary>
        public string Name { get; set; }
    }
}
