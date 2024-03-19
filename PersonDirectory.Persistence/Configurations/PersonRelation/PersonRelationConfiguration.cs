using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Schema;

namespace PersonDirectory.Persistence.Configurations.PersonRelation
{
    public class PersonRelationConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Person.PersonRelation.PersonRelation>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.Person.PersonRelation.PersonRelation> builder)
        {
            builder.ToTable("PersonRelations", TableSchema.PERSON);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);

            builder.HasOne(x => x.PersonRelationType).WithMany();

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
