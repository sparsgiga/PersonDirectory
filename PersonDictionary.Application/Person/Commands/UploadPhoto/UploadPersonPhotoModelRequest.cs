using Microsoft.AspNetCore.Http;

namespace PersonDirectory.Application.Person.Commands.UploadPhoto
{
    /// <summary>
    /// Represents a request to upload a photo
    /// </summary>
    public class UploadPersonPhotoModelRequest
    {
        /// <summary>
        /// The unique identifier of the person for whom the photo is being uploaded.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The photo file to be uploaded for the person.
        /// </summary>
        public IFormFile Photo { get; set; }
    }
}
