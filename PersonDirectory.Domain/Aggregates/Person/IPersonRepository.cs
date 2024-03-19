using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Domain.Aggregates.Person
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person?> GetAllDetailsByIdAsync(int Id);
    }
}
