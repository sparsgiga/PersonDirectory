using Microsoft.EntityFrameworkCore;
using PersonDirectory.Domain.Aggregates.Person.PersonRelation;
using PersonDirectory.Persistence.Context;
using PersonDirectory.Persistence.Repositories.Base;

namespace PersonDirectory.Persistence.Repositories
{
    internal class PersonRelationRepository(PersonDirectoryDbContext context) : Repository<PersonRelation>(context), IPersonRelationRepository
    {
        public IQueryable<PersonRelation> GetAllRelationsAsync() =>
            context.PersonRelations.Include(x => x.Person).Include(x => x.PersonRelationType).Include(x => x.RelatedPerson);
    }
}
