namespace PersonDirectory.Application.Person.Commands.DeletePhoto
{
    /// <summary>
    /// Represents a request to delete the photo of a person identified by their unique identifier.
    /// </summary>
    public class DeletePersonPhotoModelRequest
    {
        /// <summary>
        /// The unique identifier of the person whose photo is to be deleted.
        /// </summary>
        public int PersonId { get; set; }
    }
}
