using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Schema;

namespace PersonDirectory.Persistence.Configurations.City
{
    public class CityConfiguration : IEntityTypeConfiguration<Domain.Aggregates.City.City>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.City.City> builder)
        {
            builder.ToTable("Cities", TableSchema.CITY);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
