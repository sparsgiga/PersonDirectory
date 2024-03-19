using PersonDirectory.Domain.Enum;

namespace PersonDirectory.Application.Person.Queries.GetPerson
{
    public class GetPersonModelResponse
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public int CityId { get; set; }
        public string Photo { get; set; }
        public PersonCityResponse City { get; set; }

        public IList<PersonPhoneNumberResponse> PhoneNumbers { get; set; }
        public IList<PersonRelationResponse> RelatedPersons { get; set; }
    }
}
