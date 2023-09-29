using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.EntityConfigurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            // Composite key configuration
            builder.HasKey(b => new { b.RentPropertyId, b.UserId });

            // Date properties configuration
            builder.Property(b => b.CheckInDate)
                .IsRequired();

            builder.Property(b => b.CheckOutDate)
                .IsRequired();

            // Relationships configuration
            builder.HasOne(b => b.RentProperty)
                .WithMany(rp => rp.Bookings)
                .HasForeignKey(b => b.RentPropertyId);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);
        }
    }
}
