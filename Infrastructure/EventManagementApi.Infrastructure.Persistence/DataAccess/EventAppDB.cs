using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApi.Infrastructure.Persistence.DataAccess;

public class EventAppDB : DbContext
{
    public EventAppDB(DbContextOptions<EventAppDB> options) : base(options)
    {
    }

    // DbSets for the entities
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Venue> Places { get; set; }
    public DbSet<Seat> Seats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations for each entity
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceConfiguration());
        modelBuilder.ApplyConfiguration(new SeatConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}