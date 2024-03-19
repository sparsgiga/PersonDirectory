namespace PersonDirectory.Application.PersonRelation.Command.Create
{
    /// <summary>
    /// Represents a request to create a new relationship between two persons.
    /// </summary>
    public class CreatePersonRelationModelRequest
    {
        /// <summary>
        /// The unique identifier of the person for whom the relationship is being defined.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// The unique identifier of the person who is related to the first person.
        /// </summary>
        public int RelatedPersonId { get; set; }

        /// <summary>
        /// The identifier of the type of relationship between the two persons.
        /// </summary>
        public int PersonRelationTypeId { get; set; }
    }
}
