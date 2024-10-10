using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventManagementApi.Core.Domain.Entities;

namespace EventManagementApi.Infrastructure.Persistence.DataAccess.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Row)
            .IsRequired();

        builder.Property(s => s.NumberOfSeats)
            .IsRequired();

        builder.Property(s => s.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasOne(s => s.Place)
            .WithMany(p => p.Seats)
            .HasForeignKey(s => s.PlaceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Creator)
            .WithMany()
            .HasForeignKey(s => s.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Modifier)
            .WithMany()
            .HasForeignKey(s => s.ModifierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(s => s.CreateDate).IsRequired(false);
        builder.Property(s => s.ModifyDate).IsRequired(false);
        builder.Property(s => s.IsDeleted).HasDefaultValue(false);

        builder.HasQueryFilter(s => s.IsDeleted == false);
    }
}