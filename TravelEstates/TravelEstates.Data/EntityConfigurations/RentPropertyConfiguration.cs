using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.EntityConfigurations
{
    public class RentPropertyConfiguration : IEntityTypeConfiguration<RentProperty>
    {
        public void Configure(EntityTypeBuilder<RentProperty> builder)
        {
            // Key configuration
            builder.HasKey(rp => rp.Id);

            builder.Property(rp => rp.Id)
                .ValueGeneratedOnAdd();

            // PropertyTypeId property configuration
            builder.Property(rp => rp.PropertyTypeId)
                .IsRequired();

            // Name property configuration
            builder.Property(rp => rp.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Location property configuration
            builder.Property(rp => rp.Location)
                .IsRequired()
                .HasMaxLength(255);

            // Description property configuration
            builder.Property(rp => rp.Description)
                .HasMaxLength(1000); // Adjust the max length as needed

            // PricePerNight property configuration
            builder.Property(rp => rp.PricePerNight)
                .IsRequired();

            // Relationships configuration
            builder.HasMany(rp => rp.Bookings)
                .WithOne(b => b.RentProperty)
                .HasForeignKey(b => b.RentPropertyId);

            builder.HasOne(rp => rp.PropertyType)
                .WithMany(pt => pt.Properties)
                .HasForeignKey(rp => rp.PropertyTypeId);
        }
    }
}
