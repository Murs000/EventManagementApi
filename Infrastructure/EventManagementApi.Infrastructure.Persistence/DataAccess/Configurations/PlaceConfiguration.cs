using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventManagementApi.Core.Domain.Entities;

namespace EventManagementApi.Infrastructure.Persistence.DataAccess.Configurations;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Address)
            .IsRequired();

        builder.HasMany(p => p.Seats)
            .WithOne(s => s.Place)
            .HasForeignKey(s => s.PlaceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Creator)
            .WithMany()
            .HasForeignKey(p => p.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Modifier)
            .WithMany()
            .HasForeignKey(p => p.ModifierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.CreateDate).IsRequired(false);
        builder.Property(p => p.ModifyDate).IsRequired(false);
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);

        builder.HasQueryFilter(p => p.IsDeleted == false);
    }
}