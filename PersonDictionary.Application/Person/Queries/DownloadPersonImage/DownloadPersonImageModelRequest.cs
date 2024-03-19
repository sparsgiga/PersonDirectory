namespace PersonDirectory.Application.Person.Queries.DownloadPersonImage
{
    /// <summary>
    /// Represents a request to download the image of a person using the image's URL.
    /// </summary>
    public class DownloadPersonImageModelRequest
    {
        /// <summary>
        /// The URL of the photo to be downloaded.
        /// </summary>
        public string PhotoUrl { get; set; }
    }
}
