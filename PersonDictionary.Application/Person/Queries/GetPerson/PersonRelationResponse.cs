using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Queries.GetPerson
{
    public class PersonRelationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
