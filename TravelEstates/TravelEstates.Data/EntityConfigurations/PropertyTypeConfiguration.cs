using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.EntityConfigurations
{
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            // Key configuration
            builder.HasKey(pt => pt.Id);

            // Name property configuration
            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Relationships configuration
            builder.HasMany(pt => pt.Properties)
                .WithOne(rp => rp.PropertyType)
                .HasForeignKey(rp => rp.PropertyTypeId);
        }
    }
}
