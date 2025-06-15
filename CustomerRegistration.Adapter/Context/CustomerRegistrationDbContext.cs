using CustomerRegistration.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration.Adapter.Context;

public class CustomerRegistrationDbContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<EventOutbox> Outbox { get; set; }

    public CustomerRegistrationDbContext() { }

    public CustomerRegistrationDbContext(DbContextOptions<CustomerRegistrationDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite("Data Source=customerdb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.NationalCode)
            .Property(p => p.Value)
            .HasColumnName("NationalCode")
            .HasMaxLength(10);

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.PhoneNumber)
            .Property(p => p.Value)
            .HasColumnName("PhoneNumber")
            .HasMaxLength(11);

        modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.Email)
            .Property(p => p.Value)
            .HasColumnName("Email")
            .HasMaxLength(50);
    }
}
