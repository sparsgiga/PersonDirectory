using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Schema;

namespace PersonDirectory.Persistence.Configurations.PersonRelationType
{
    public class PersonRelationTypeConfiguration : IEntityTypeConfiguration<Domain.Aggregates.PersonRelationType.PersonRelationType>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.PersonRelationType.PersonRelationType> builder)
        {
            builder.ToTable("PersonRelationTypes", TableSchema.PERSON);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
