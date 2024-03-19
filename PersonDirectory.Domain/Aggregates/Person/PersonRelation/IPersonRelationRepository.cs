using PersonDirectory.Domain.Interfaces;

namespace PersonDirectory.Domain.Aggregates.Person.PersonRelation
{
    public interface IPersonRelationRepository : IRepository<PersonRelation>
    {
        IQueryable<PersonRelation> GetAllRelationsAsync();
    }
}
