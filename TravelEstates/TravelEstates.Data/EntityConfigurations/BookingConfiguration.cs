using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.EntityConfigurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.RentPropertyId)
                .IsRequired();

            builder.Property(b => b.UserId)
                .IsRequired();

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
