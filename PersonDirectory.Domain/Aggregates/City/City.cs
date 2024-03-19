using PersonDirectory.Domain.Base;
using PersonDirectory.Domain.Base.Primitives;

namespace PersonDirectory.Domain.Aggregates.City
{
    public class City : Entity<int>, IAggregateRoot
    {
        public City(string name)
        {
            Name = name.Trim();
        }
        public string Name { get; private set; }


        public static City Create(string name)
        {
            return new City(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
