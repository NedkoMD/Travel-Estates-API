using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Data.EntityConfigurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            // Key configuration
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedNever();

            // UserId property configuration
            builder.Property(t => t.UserId)
                .IsRequired();

            // ValidUntil property configuration
            builder.Property(t => t.ValidUntil)
                .IsRequired();

            // IsUsed property configuration
            builder.Property(t => t.IsUsed)
                .IsRequired();

            // Value property configuration
            builder.Property(t => t.Value)
                .IsRequired();

            // Type property configuration
            builder.Property(t => t.Type)
                .IsRequired();

            // Relationships configuration
            builder.HasOne(t => t.User)
                .WithMany(u => u.Tokens)
                .HasForeignKey(t => t.UserId);
        }
    }
}
