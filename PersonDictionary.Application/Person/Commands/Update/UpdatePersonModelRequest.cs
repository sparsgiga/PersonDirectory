using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Commands.Update
{
    /// <summary>
    /// Represents a request to update the information of an existing person identified by their unique identifier.
    /// </summary>
    public class UpdatePersonModelRequest
    {
        /// <summary>
        /// The unique identifier of the person to be updated.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The updated name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The updated last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The updated personal number of the person.
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// The updated birth date of the person.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The updated gender of the person.
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// The updated city identifier where the person resides.
        /// </summary>
        public int CityId { get; set; }
    }
}
