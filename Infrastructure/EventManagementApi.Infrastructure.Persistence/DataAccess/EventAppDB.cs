using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApi.Infrastructure.Persistence.DataAccess;

public class EventAppDB : DbContext
{
    public EventAppDB(DbContextOptions<EventAppDB> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}

