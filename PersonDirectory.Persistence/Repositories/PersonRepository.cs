using Microsoft.EntityFrameworkCore;
using PersonDirectory.Domain.Aggregates.Person;
using PersonDirectory.Persistence.Context;
using PersonDirectory.Persistence.Repositories.Base;

namespace PersonDirectory.Persistence.Repositories
{
    public class PersonRepository(PersonDirectoryDbContext context) : Repository<Person>(context), IPersonRepository
    {
        public async Task<Person?> GetAllDetailsByIdAsync(int Id)
        {
            var response = await context.Persons.Where(x => x.Id == Id)
               .Include(x => x.City)
               .Include(x => x.RelatedPersons).ThenInclude(x => x.RelatedPerson)
               .Include(x => x.PhoneNumbers).ThenInclude(x => x.PhoneNumberType)
               .FirstOrDefaultAsync();

            return response;
        }
    }
}
