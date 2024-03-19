namespace PersonDirectory.Application.City.Queries.Get
{
    /// <summary>
    /// Represents a request for querying city data, supporting optional filtering and pagination.
    /// </summary>
    public class CityModelRequest
    {
        /// <summary>
        /// An optional query string used for filtering cities based on matching criteria.
        /// </summary>
        public string? FilterQuery { get; set; }

        /// <summary>
        /// The size of the page for pagination. Specifies the number of cities to include in a single page.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The page number for pagination, indicating which page of the results to retrieve.
        /// </summary>
        public int? PageNumber { get; set; }
    }
}
