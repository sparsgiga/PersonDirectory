namespace PersonDirectory.Application.PersonRelation.Command.Delete
{
    /// <summary>
    /// Represents a request to delete an existing relationship between two persons.
    /// </summary>
    public class DeletePersonRelationModelRequest
    {
        /// <summary>
        /// The unique identifier of the person from whom the relationship is being removed.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The unique identifier of the other person involved in the relationship.
        /// </summary>
        public int RelatedPersonId { get; set; }

        /// <summary>
        /// The identifier of the type of relationship that is being deleted.
        /// </summary>
        public int PersonRelationTypeId { get; set; }
    }
}
