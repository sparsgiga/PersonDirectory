using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Persistence.Context;
using PersonDirectory.Persistence.Repositories.Base;

namespace PersonDirectory.Persistence.Repositories
{
    public class PersonRelationTypeRepository : Repository<PersonRelationType>, IPersonRelationTypeRepository
    {
        public PersonRelationTypeRepository(PersonDirectoryDbContext context)
            : base(context)
        {
        }
    }
}
