using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Schema;

namespace PersonDirectory.Persistence.Configurations.PhoneNumberType
{
    public class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<Domain.Aggregates.PhoneNumberType.PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.PhoneNumberType.PhoneNumberType> builder)
        {
            builder.ToTable("PhoneNumberTypes", TableSchema.PERSON);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
