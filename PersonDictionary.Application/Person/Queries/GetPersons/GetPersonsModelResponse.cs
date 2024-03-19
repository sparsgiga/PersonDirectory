using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Queries.GetPersons
{
    public class GetPersonsModelResponse
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }

    }
}
