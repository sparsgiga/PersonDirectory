using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonDirectory.Domain.Aggregates.City;
using PersonDirectory.Domain.Aggregates.Person;
using PersonDirectory.Domain.Aggregates.Person.PersonRelation;
using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Domain.Aggregates.PhoneNumberType;
using PersonDirectory.Domain.Interfaces;
using PersonDirectory.Persistence.Context;
using PersonDirectory.Persistence.Repositories;
using PersonDirectory.Persistence.Repositories.UnitOfWork;

namespace PersonDirectory.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<PersonDirectoryDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("PersonDirectory")));

            services.AddScoped<PersonDirectoryDbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPersonRelationRepository, PersonRelationRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonRelationTypeRepository, PersonRelationTypeRepository>();
            services.AddScoped<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();

            return services;
        }
    }
}
