using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventManagementApi.Core.Domain.Entities;

namespace EventManagementApi.Infrastructure.Persistence.DataAccess.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.HasOne(e => e.Venue)
            .WithMany(p => p.Events)
            .HasForeignKey(e => e.VenueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Creator)
            .WithMany()
            .HasForeignKey(e => e.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Modifier)
            .WithMany()
            .HasForeignKey(e => e.ModifierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreateDate).IsRequired(false);
        builder.Property(e => e.ModifyDate).IsRequired(false);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);

        builder.HasQueryFilter(e => e.IsDeleted == false);
    }
}