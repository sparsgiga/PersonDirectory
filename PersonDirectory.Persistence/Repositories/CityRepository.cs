using PersonDirectory.Domain.Aggregates.City;
using PersonDirectory.Persistence.Context;
using PersonDirectory.Persistence.Repositories.Base;

namespace PersonDirectory.Persistence.Repositories
{
    internal class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PersonDirectoryDbContext context)
            : base(context)
        {
        }
    }


}
