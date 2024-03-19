using PersonDirectory.Common.Exceptions;
using PersonDirectory.Domain.Base;
using PersonDirectory.Domain.Base.Primitives;
using PersonDirectory.Domain.Enum;
using PersonDirectory.Domain.Resources;

namespace PersonDirectory.Domain.Aggregates.Person
{
    public class Person : Entity<int>, IAggregateRoot
    {
        private readonly List<PersonPhoneNumber> phoneNumbers;

        public Person(
                    string name,
                    string lastName,
                    string personalNumber,
                    DateTime birthDate,
                    GenderEnum gender,
                    int cityId)
        {
            Name = name;
            LastName = lastName;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            Gender = gender;
            Photo = string.Empty;
            CityId = cityId;
        }

        public Person()
        {
            phoneNumbers = new List<PersonPhoneNumber>();
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PersonalNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Photo { get; private set; }
        public GenderEnum Gender { get; private set; }
        public int CityId { get; private set; }
        public City.City City { get; private set; }

        public IReadOnlyCollection<PersonPhoneNumber> PhoneNumbers => phoneNumbers;
        public IReadOnlyCollection<PersonRelation.PersonRelation> RelatedPersons;

        public static Person Create(string name, string lastName, string personalNumber, DateTime birthDate, GenderEnum gender, int cityId)
            => new Person(name, lastName, personalNumber, birthDate, gender, cityId);

        public void Update(string name, string lastName, string personalNumber, DateTime birthDate, GenderEnum gender, int cityId)
        {
            Name = name;
            LastName = lastName;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            Gender = gender;
            CityId = cityId;
        }
        public void UpdatePhotoUrl(string photoUrl) => Photo = photoUrl;
        public void DeletePhoto() => Photo = string.Empty;
        public void AddPhoneNumber(PersonPhoneNumber phoneNumber)
        {
            phoneNumbers.Add(phoneNumber);
        }
        public void DeleteNumber(int id)
        {
            var phoneNumber = phoneNumbers.FirstOrDefault(x => x.Id == id);

            if (phoneNumber == null)
                throw new NotFoundException(string.Format(ExceptionMessageResources.NotFound,
                                                               nameof(PersonPhoneNumber), id));
            phoneNumber.Delete();
        }
        public void UpdateNumber(int phoneNumberId, int phoneNumberTypeId, string number)
        {
            var phoneNumber = phoneNumbers.FirstOrDefault(x => x.Id == phoneNumberId);

            if (phoneNumber == null)
                throw new NotFoundException(string.Format(ExceptionMessageResources.NotFound,
                                                               nameof(PersonPhoneNumber), phoneNumberId));
            phoneNumber.Update(phoneNumberTypeId, number);
        }
    }
}
