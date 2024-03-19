using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersonDirectory.Domain.Aggregates.City;
using PersonDirectory.Domain.Aggregates.Person;
using PersonDirectory.Domain.Aggregates.Person.PersonRelation;
using PersonDirectory.Domain.Aggregates.PersonRelationType;
using PersonDirectory.Domain.Aggregates.PhoneNumberType;
using PersonDirectory.Persistence.Configurations.City;
using PersonDirectory.Persistence.Configurations.Person;
using PersonDirectory.Persistence.Configurations.PersonRelation;
using PersonDirectory.Persistence.Configurations.PersonRelationType;
using PersonDirectory.Persistence.Configurations.PhoneNumber;
using PersonDirectory.Persistence.Configurations.PhoneNumberType;

namespace PersonDirectory.Persistence.Context
{
    public class PersonDirectoryDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonPhoneNumber> PersonPhoneNumbers { get; set; }
        public DbSet<PersonRelation> PersonRelations { get; set; }
        public DbSet<PersonRelationType> PersonRelationTypes { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<City> Cities { get; set; }

        public PersonDirectoryDbContext(DbContextOptions<PersonDirectoryDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonRelationConfiguration());
            modelBuilder.ApplyConfiguration(new PersonRelationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberTypeConfiguration());
        }
    }
}