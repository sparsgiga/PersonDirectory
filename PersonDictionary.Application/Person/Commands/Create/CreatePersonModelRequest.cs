using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Commands.Create
{
    public class CreatePersonModelRequest
    {
        /// <summary>
        ///  first name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  personal identification number of the person.
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        ///  birth date of the person.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        ///  gender of the person.
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        ///  identifier for the city where the person lives.
        /// </summary>
        public int CityId { get; set; }
    }
}
