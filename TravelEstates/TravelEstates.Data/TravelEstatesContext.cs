using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelEstates.Data.EntityConfigurations;
using TravelEstates.Data.Models.Entities.Base;

public class TravelEstatesContext : IdentityDbContext<User, Role, string>
{
    public TravelEstatesContext(DbContextOptions<TravelEstatesContext> options)
        : base(options)
    {
    }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<PropertyType> PropertyTypes { get; set; }

    public DbSet<RentProperty> RentingProperties { get; set; }

    public DbSet<Token> Tokens { get; set; }

    public DbSet<User> Users { get; set; }

    public class YourDbContextSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = "1", Name = "Flat" },
                new PropertyType { Id = "2", Name = "House" },
                new PropertyType { Id = "3", Name = "Single room" },
                new PropertyType { Id = "4", Name = "Hotel room" },
                new PropertyType { Id = "5", Name = "Boat cabin" }
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RentPropertyConfiguration());
        modelBuilder.ApplyConfiguration(new TokenConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        YourDbContextSeed.SeedData(modelBuilder);
    }
}
