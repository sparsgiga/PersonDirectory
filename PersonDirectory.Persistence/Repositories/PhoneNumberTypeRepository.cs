using PersonDirectory.Domain.Aggregates.PhoneNumberType;
using PersonDirectory.Persistence.Context;
using PersonDirectory.Persistence.Repositories.Base;

namespace PersonDirectory.Persistence.Repositories
{
    public class PhoneNumberTypeRepository : Repository<PhoneNumberType>, IPhoneNumberTypeRepository
    {
        public PhoneNumberTypeRepository(PersonDirectoryDbContext context)
            : base(context)
        {
        }
    }
}
