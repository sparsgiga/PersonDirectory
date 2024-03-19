using PersonDirectory.Domain.Base;
using PersonDirectory.Domain.Base.Primitives;

namespace PersonDirectory.Domain.Aggregates.PersonRelationType
{
    public class PersonRelationType(string name) : Entity<int>, IAggregateRoot
    {
        public string Name { get; private set; } = name.Trim();

        public static PersonRelationType Create(string name)
        {
            return new PersonRelationType(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
