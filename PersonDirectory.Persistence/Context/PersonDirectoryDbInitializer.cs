using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonDirectory.Domain.Aggregates.City;
using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Domain.Aggregates.PhoneNumberType;

namespace PersonDirectory.Persistence.Context
{
    public class PersonDirectoryDbInitializer(PersonDirectoryDbContext _dbContext, ILogger<PersonDirectoryDbInitializer> _logger)
    {
        public async Task InitialDataAsync()
        {
            try
            {
                await _dbContext.Database.MigrateAsync();

                if (!await _dbContext.Cities.AnyAsync())
                {
                    var cities = new List<City>()
                    {
                        City.Create("Tbilisi"),
                        City.Create("Batumi"),
                        City.Create("Kutaisi"),
                        City.Create("Sachkhere"),
                        City.Create("Chiatura"),
                        City.Create("Telavi")
                    };

                    await _dbContext.Cities.AddRangeAsync(cities);
                }

                if (!await _dbContext.PersonRelationTypes.AnyAsync())
                {
                    var cities = new List<PersonRelationType>()
                    {
                        PersonRelationType.Create("Colleague"),
                        PersonRelationType.Create("Familliar"),
                        PersonRelationType.Create("Relative"),
                        PersonRelationType.Create("Other"),
                    };

                    await _dbContext.PersonRelationTypes.AddRangeAsync(cities);
                }

                if (!await _dbContext.PhoneNumberTypes.AnyAsync())
                {
                    var cities = new List<PhoneNumberType>()
                    {
                        PhoneNumberType.Create("Personal"),
                        PhoneNumberType.Create("Office"),
                        PhoneNumberType.Create("Home"),
                    };

                    await _dbContext.PhoneNumberTypes.AddRangeAsync(cities);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured while inserting initial values in database. message:{ex.Message}");
                throw;
            }
        }

    }
}
