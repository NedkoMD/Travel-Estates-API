using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // FirstName property configuration
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            // LastName property configuration
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);

            // Verified property configuration
            builder.Property(u => u.Verified)
                .IsRequired();

            // Relationships configuration
            builder.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.HasMany(u => u.Tokens)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }
}
