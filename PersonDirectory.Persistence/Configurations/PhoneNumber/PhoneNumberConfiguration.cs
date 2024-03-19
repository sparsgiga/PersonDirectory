using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Schema;

namespace PersonDirectory.Persistence.Configurations.PhoneNumber
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Person.PersonPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.Person.PersonPhoneNumber> builder)
        {
            builder.ToTable("PersonPhoneNumbers", TableSchema.PERSON);

            builder.ToTable(t => t.HasCheckConstraint("CK_PersonPhoneNumber_PhoneNumber_MinLength", "LEN(PhoneNumber) >= 4"));

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
