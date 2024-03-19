using PersonDirectory.Domain.Base;

namespace PersonDirectory.Domain.Aggregates.Person
{
    public class PersonPhoneNumber(
        string phoneNumber,
        int phoneNumberTypeId) : Entity<int>
    {
        public string PhoneNumber { get; private set; } = phoneNumber;
        public int PersonId { get; private set; }
        public int PhoneNumberTypeId { get; private set; } = phoneNumberTypeId;

        public virtual Person Person { get; private set; }
        public virtual PhoneNumberType.PhoneNumberType PhoneNumberType { get; private set; }


        public static PersonPhoneNumber Create(string phoneNumber, int phoneNumberTypeId)
        {
            return new PersonPhoneNumber(phoneNumber, phoneNumberTypeId);
        }
        public void Update(int phoneNumberTypeId, string phoneNumber)
        {
            PhoneNumberTypeId = phoneNumberTypeId;
            PhoneNumber = phoneNumber;
        }
    }

}
