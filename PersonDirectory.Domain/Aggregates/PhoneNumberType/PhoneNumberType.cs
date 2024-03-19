using PersonDirectory.Domain.Base;
using PersonDirectory.Domain.Base.Primitives;

namespace PersonDirectory.Domain.Aggregates.PhoneNumberType
{
    public class PhoneNumberType : Entity<int>, IAggregateRoot
    {
        public PhoneNumberType(string name)
        {
            Name = name.Trim();
        }
        public string Name { get; private set; }


        public static PhoneNumberType Create(string name)
        {
            return new PhoneNumberType(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
