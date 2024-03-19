namespace PersonDirectory.Application.City.Commands.Create
{
    /// <summary>
    /// Represents a request to create a new city.
    /// </summary>
    public class CreateCityModelRequest
    {
        /// <summary>
        /// Gets or sets the name of the city to be created.
        /// </summary>
        public string Name { get; set; }
    }
}
